using System.Collections.Generic;
using BooksStat.BAL.Core.Models;
using BooksStat.DAP.SqLite.Models;

namespace BooksStat.BAL.Core.Interfaces
{
    public interface IBookRepository
    {
        bool AddOrUpdate(Book book);

        void SetStatus(Book book, Enums.Status status);

        void SetRate(Book book, Enums.Rating rating);

        IEnumerable<Book> GetLastUpdates();

        IEnumerable<Book> Search(string searchText, OrderBy order);

        IEnumerable<Book> GetByStatus(Enums.Status status, OrderBy order);
    }
}