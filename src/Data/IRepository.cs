using System.Threading.Tasks;

namespace VueClassValidation.Data
{
  public interface IRepository
  {
    void Add<T>(T entity);
    void Delete<T>(T entity);
    Task<bool> SaveAllAsync();
  }
}