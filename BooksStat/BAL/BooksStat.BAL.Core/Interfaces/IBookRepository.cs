using System.Collections.Generic;
using System.Threading.Tasks;
using BooksStat.BAL.Core.Models;
using BooksStat.DAP.SqLite.Models;

namespace BooksStat.BAL.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddOrUpdateAsync(Book book);

        Task SetStatusAsync(Enums.Status status);

        Task RateAsync(Enums.Rating rating);

        Task<IEnumerable<Book>> SearchAsync(string searchText, OrderBy order);

        Task<IEnumerable<Book>> GetByStatusAsync(Enums.Status status, OrderBy order);
    }
}