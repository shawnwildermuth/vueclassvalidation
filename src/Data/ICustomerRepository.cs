using System.Collections.Generic;
using System.Threading.Tasks;
using VueClassValidation.Data.Entities;

namespace VueClassValidation.Data
{
  public interface ICustomerRepository : IRepository
  {
    Task<Customer[]> GetCustomersAsync();
    Task<Customer> GetCustomerAsync(int id);
    Task<Customer> GetCustomerByUserAsync(string id);
    Task<bool> HasCustomerAsync(string userName);
  }
}