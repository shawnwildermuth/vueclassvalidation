using System.Collections.Generic;
using System.Threading.Tasks;
using VueClassValidation.Data.Entities;

namespace VueClassValidation.Data
{
  public interface IShowRepository : IRepository
  {
    Task<IEnumerable<Show>> GetLatestShowsAsync();
    Task<Show> GetShowAsync(int id);

    Task<IEnumerable<Ticket>> GetTicketsForShowAsync(int showId);
    Task<IEnumerable<Ticket>> GetTicketsAsync(int[] ticketIds);
  }
}