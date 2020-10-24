namespace BooksStat.BAL.Core.Interfaces
{
    using System.Collections.Generic;
    using BooksStat.BAL.Core.Models;

    public interface IBookRepository
    {
        bool AddOrUpdate(Book book);

        void SetStatus(int id, Enums.Status status);

        void SetRate(int id, Enums.Rating rating);

        IEnumerable<Book> GetLastUpdates();

        IEnumerable<Book> Search(string searchText, OrderBy order);

        IEnumerable<Book> GetByStatus(Enums.Status status, OrderBy order);
    }
}