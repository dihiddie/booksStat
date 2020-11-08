namespace BooksStat.BAL.Core.Interfaces
{
    using System.Collections.Generic;
    using BooksStat.BAL.Core.Models;

    public interface IBookRepository
    {
        void SetTestData();

        int AddOrUpdate(Book book);

        void SetStatus(int id, Enums.Status status);

        void SetRate(int id, Enums.Rating rating);

        IEnumerable<Book> GetLastUpdates(int take);

        IEnumerable<Book> Search(string searchText);

        IEnumerable<Book> Filter(Enums.Status? status, Enums.Rating? rating, int? month, int? year, bool? isFavorite);

        IEnumerable<int> GetEnteredYears();
    }
}