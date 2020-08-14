using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueClassValidation.Data;
using VueClassValidation.Data.Entities;

namespace VueClassValidation.Data
{
  public class CustomerRepository : BaseRepository<CustomerContext>, ICustomerRepository
  {
    public CustomerRepository(CustomerContext context) : base(context)
    {
    }

    public Task<Customer> GetCustomerAsync(int id)
    {
      return Context.Customers
        .Where(c => c.Id == id)
        .FirstOrDefaultAsync();
    }

    public Task<Customer> GetCustomerByUserAsync(string id)
    {
      return Context.Customers
        .Where(c => c.UserName == id)
        .FirstOrDefaultAsync();
    }

    public Task<Customer[]> GetCustomersAsync()
    {
      return Context.Customers.ToArrayAsync();
    }

    public Task<bool> HasCustomerAsync(string userName)
    {
      return Context.Customers.AnyAsync(w => w.UserName.ToUpper() == userName.ToUpper());
    }

  }
}

