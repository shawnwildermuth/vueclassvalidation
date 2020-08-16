<template>
  <div>
    <div class="alert alert-info" v-if="isBusy">Loading...</div>
    <div class="row">
      <div class="col">
        <table class="table table-sm table-bordered">
          <tbody>
            <tr v-for="c in customers" :key="c.id">
              <td>{{c.id}}</td>
              <td>{{c.fullName}}</td>
              <td>{{c.company}}</td>
              <td>{{c.phone}}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="col">
        <div class="alert alert-warning" v-if="error">{{ error }}</div>
        <h3>New Customer</h3>
        <customer-editor :customer="customer" @customerEdited="onEditComplete()"></customer-editor>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {
  defineComponent,
  reactive,
  onMounted,
  ref,
  Ref,
  watchEffect,
} from "vue";
import http from "axios";
import Customer from "@/models/Customer";
import CustomerEditor from "@/components/CustomerEditor.vue";

export default defineComponent({
  name: "App",
  setup() {
    const customers = reactive([] as Array<Customer>);
    const customer = ref(new Customer());
    const isBusy = ref(false);
    const message = ref("");

    onMounted(async () => {
      try {
        customers.length = 0; // Clear it
        const result = await http.get<Array<Customer>>("/api/customers");
        result.data.forEach((c) => customers.push(c));
      } catch (error) {
        message.value = "Failed to load data...";
      }
      finally { isBusy.value = false; }
    });

    async function onEditComplete() {
      try {
        isBusy.value = true;
        message.value = "";
        const result = await http.post<Customer>("/api/customers", customer.value);
        customers.push(result.data);
        customer.value = new Customer();
      } catch {
        message.value = "Failed to save the customer"
      } finally {
        isBusy.value = false;
      }
    }

    return {
      customers,
      customer,
      isBusy,
      message,
      onEditComplete,
    };
  },
  components: {
    CustomerEditor,
  },
});
</script>

