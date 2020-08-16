<template>
  <div>
    <div class="form-group">
      <label for="firstName">First Name</label>
      <input class="form-control" name="firstName" v-model="customer.firstName" />
      <span
        v-if="customer.errors.firstName"
        class="text-danger small p-0 m-0"
      >{{ customer.errors.firstName }}</span>
    </div>
    <div class="form-group">
      <label for="lastName">Last Name</label>
      <input class="form-control" name="lastName" v-model="customer.lastName" />
      <span
        v-if="customer.errors.lastName"
        class="text-danger small p-0 m-0"
      >{{ customer.errors.lastName }}</span>
    </div>
    <div class="form-group">
      <label for="phoneNumber">Phone</label>
      <input class="form-control" name="phoneNumber" v-model="customer.phoneNumber" />
      <span
        v-if="customer.errors.phoneNumber"
        class="text-danger small p-0 m-0"
      >{{ customer.errors.phoneNumber }}</span>
    </div>
    <div class="form-group">
      <label for="companyName">Company</label>
      <input class="form-control" name="companyName" v-model="customer.companyName" />
      <span
        v-if="customer.errors.companyName"
        class="text-danger small p-0 m-0"
      >{{ customer.errors.companyName }}</span>
    </div>
    <div class="border p-1 bg-light">
      <div class="form-group">
        <label for="addressLine1">Address</label>
        <input class="form-control" name="addressLine1" v-model="customer.addressLine1" />
        <span
          v-if="customer.errors.addressLine1"
          class="text-danger small p-0 m-0"
        >{{ customer.errors.addressLine1 }}</span>
      </div>
      <div class="form-group">
        <input class="form-control" name="addressLine2" v-model="customer.addressLine2" />
        <span
          v-if="customer.errors.addressLine2"
          class="text-danger small p-0 m-0"
        >{{ customer.errors.addressLine2 }}</span>
      </div>
      <div class="form-group">
        <input class="form-control" name="addressLine3" v-model="customer.addressLine3" />
        <span
          v-if="customer.errors.addressLine3"
          class="text-danger small p-0 m-0"
        >{{ customer.errors.addressLine3 }}</span>
      </div>
      <div class="form-group">
        <label for="cityTown">City</label>
        <input class="form-control" name="cityTown" v-model="customer.cityTown" />
        <span
          v-if="customer.errors.cityTown"
          class="text-danger small p-0 m-0"
        >{{ customer.errors.cityTown }}</span>
      </div>
      <div class="form-group">
        <label for="stateProvince">State</label>
        <input class="form-control" name="stateProvince" v-model="customer.stateProvince" />
        <span
          v-if="customer.errors.stateProvince"
          class="text-danger small p-0 m-0"
        >{{ customer.errors.stateProvince }}</span>
      </div>
      <div class="form-group">
        <label for="postalCode">Zipcode</label>
        <input class="form-control" name="postalCode" v-model="customer.postalCode" />
        <span
          v-if="customer.errors.postalCode"
          class="text-danger small p-0 m-0"
        >{{ customer.errors.postalCode }}</span>
      </div>
    </div>
    <div>
      <button class="btn btn-success" @click="onSave()" :disabled="!customer.isValid">Save</button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, watchEffect, computed } from "vue";
import Customer from "@/models/Customer";
export default defineComponent({
  name: "CustomerEditor",
  props: {
    customer: {
      type: Customer,
      required: true,
    },
  },
  setup(props, { emit }) {
    const onSave = async () => {
      await props.customer.validateModel();
      if (props.customer.isValid) {
        emit("customerEdited");
      }
    };

    watchEffect(async () => {
      await props.customer.validateModel();
    });

    return {
      onSave,
    };
  },
});
</script>