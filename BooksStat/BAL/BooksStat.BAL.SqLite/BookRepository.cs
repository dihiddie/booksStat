namespace BooksStat.BAL.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BooksStat.BAL.Core.Exceptions;
    using BooksStat.BAL.Core.Interfaces;
    using BooksStat.DAL.SqLite.Models;
    using BooksStat.Utils.Enum;
    using SQLite;
    using Book = Core.Models.Book;
    using Rating = Core.Enums.Rating;
    using Status = Core.Enums.Status;

    public sealed class BookRepository : IBookRepository
    {
        private readonly SQLiteConnection database;

        public BookRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);

            // DropTables();
            CreateTableIfNotExists();
            CleanDatabase();
            SetTestData();
        }

        public void SetTestData()
        {
            for (int i = 0; i < 10; i++)
            {
                var id = AddOrUpdate(new Book
                                                  {
                                                      AuthorName = $"TestAuthor_{i}",
                                                      BookName = $"TestBookName_{i}",
                                                      // IsFavorite = true
                                                  });
                SetStatus(id, Status.Readed);
                SetRate(id, Rating.Four);
            }

            for (int i = 10; i < 20; i++)
            {
                var id = AddOrUpdate(new Book
                                                  {
                                                      AuthorName = $"TestAuthor_{i}",
                                                      BookName = $"TestBookName_{i}",
                                                  });
                SetStatus(id, Status.WantToRead);
            }
        }

        public int AddOrUpdate(Book book)
        {
            try
            {
                var dbBook = new DAL.SqLite.Models.Book
                                 {
                                     Id = book.Id,
                                     AuthorName = book.AuthorName,
                                     Name = book.BookName,
                                     CreateDateTime = DateTime.Now,
                                     UpdateDateTime = DateTime.Now,
                                     IsFavorite = book.IsFavorite
                                 };

                if (dbBook.Id != 0) database.Update(dbBook);
                else database.Insert(dbBook);

                return dbBook.Id;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Произошла ошибка при сохранении данных. Пожалуйста, попробуйте позже");
            }
        }

        public void SetStatus(int id, Status status)
        {
            var bookStatusLink = GetBookStatusLink(id);
            if (bookStatusLink == null) database.Insert(new BookStatusLink { BookId = id, StatusId = (int)status });
            else
            {
                bookStatusLink.StatusId = (int)status;
                database.Update(bookStatusLink);
            }
        }

        public void SetRate(int id, Rating rating)
        {
            var bookRatingLink = GetBookRatingLink(id);
            if (bookRatingLink == null) database.Insert(new BookRatingLink { BookId = id, RatingId = (int)rating });
            else
            {
                bookRatingLink.RatingId = (int)rating;
                database.Update(bookRatingLink);
            }
        }

        public IEnumerable<Book> GetLastUpdates(int take = 15)
        {
            var booksInDb = database.Table<DAL.SqLite.Models.Book>().OrderBy(x => x.UpdateDateTime).Take(take).ToList();
            return MapFromDatabaseBooks(booksInDb);
        }

        public IEnumerable<Book> Search(string searchText)
        {
            var searchByAuthorName = database.Table<DAL.SqLite.Models.Book>().Where(x => x.AuthorName.Contains(searchText)).ToList();
            var searchByBookName = database.Table<DAL.SqLite.Models.Book>().Where(x => x.Name.Contains(searchText)).ToList();

            searchByAuthorName.AddRange(searchByBookName);
            return MapFromDatabaseBooks(searchByAuthorName);
        }

        public IEnumerable<Book> Filter(Status? status, Rating? rating, int? month, int? year, bool? isFavorite)
        {
            var books = new List<DAL.SqLite.Models.Book>();

            if (status.HasValue)
            {
                var booksByStatusIds = database.Table<BookStatusLink>().Where(x => x.StatusId == (int)status).Select(x => x.BookId).Distinct();
                books.AddRange(database.Table<DAL.SqLite.Models.Book>().Where(x => booksByStatusIds.Contains(x.Id)));
            }

            if (rating.HasValue)
            {
                var booksByRatingIds = database.Table<BookRatingLink>().Where(x => x.RatingId == (int)rating).Select(x => x.BookId).Distinct();
                if (books.Any()) books = books.Where(x => booksByRatingIds.Contains(x.Id)).ToList();
                else books.AddRange(database.Table<DAL.SqLite.Models.Book>().Where(x => booksByRatingIds.Contains(x.Id)));
            }

            if (month.HasValue)
            {
                if (books.Any()) books = books.Where(x => x.CreateDateTime.Month == month).ToList();
                else books.AddRange(database.Table<DAL.SqLite.Models.Book>().Where(x => x.CreateDateTime.Month == month));
            }

            if (year.HasValue)
            {
                if (books.Any()) books = books.Where(x => x.CreateDateTime.Year == year).ToList();
                else books.AddRange(database.Table<DAL.SqLite.Models.Book>().Where(x => x.CreateDateTime.Year == year));
            }

            if (isFavorite.HasValue)
            {
                if (books.Any()) books = books.Where(x => x.IsFavorite == isFavorite).ToList();
                else books.AddRange(database.Table<DAL.SqLite.Models.Book>().Where(x => x.IsFavorite == isFavorite));
            }

            return MapFromDatabaseBooks(books);
        }

        public IEnumerable<int> GetEnteredYears() =>
            database.Table<DAL.SqLite.Models.Book>().Select(x => x.CreateDateTime).Select(x => x.Year)
                .Distinct();

        private void CreateTableIfNotExists()
        {
            database.CreateTable<DAL.SqLite.Models.Book>();
            database.CreateTable<DAL.SqLite.Models.Status>();
            database.CreateTable<BookStatusLink>();
            database.CreateTable<DAL.SqLite.Models.Rating>();
            database.CreateTable<BookRatingLink>();

            SeedStatusData();
            SeedRatingData();
        }

        private BookStatusLink GetBookStatusLink(int bookId) => database.Table<BookStatusLink>().FirstOrDefault(x => x.BookId == bookId);

        private BookRatingLink GetBookRatingLink(int bookId) => database.Table<BookRatingLink>().FirstOrDefault(x => x.BookId == bookId);

        private void SeedStatusData()
        {
            if (database.Table<Status>().Any()) return;
            foreach (var statusName in EnumExtensions.GetEnumAsList<Status>())
                database.Insert(new DAL.SqLite.Models.Status { Name = statusName });
        }

        private void SeedRatingData()
        {
            if (database.Table<Rating>().Any()) return;
            foreach (var ratingName in EnumExtensions.GetEnumAsList<Rating>())
                database.Insert(new DAL.SqLite.Models.Rating() { Name = ratingName });
        }

        private void CleanDatabase()
        {
            var books = database.Table<DAL.SqLite.Models.Book>().ToList();
            foreach (var book in books) database.Delete(book);
        }

        private void DropTables()
        {
            database.DropTable<BookStatusLink>();
            database.DropTable<BookRatingLink>();

            database.DropTable<DAL.SqLite.Models.Status>();
            database.DropTable<DAL.SqLite.Models.Rating>();
            database.DropTable<DAL.SqLite.Models.Book>();
        }

        private IEnumerable<Book> MapFromDatabaseBooks(IEnumerable<DAL.SqLite.Models.Book> dbBooks)
        {
            var books = new List<Book>();
            foreach (var dbBook in dbBooks)
            {
                var book = new Book
                               {
                                   Id = dbBook.Id,
                                   AuthorName = dbBook.AuthorName,
                                   BookName = dbBook.Name,
                                   IsFavorite = dbBook.IsFavorite
                               };
                var bookRating = GetBookRatingLink(dbBook.Id);
                var bookStatus = GetBookStatusLink(dbBook.Id);

                if (bookRating != null) book.SelectedRating = ((Rating)bookRating.RatingId).GetEnumDescription();
                if (bookStatus != null) book.SelectedStatus = ((Status)bookStatus.StatusId).GetEnumDescription();

                books.Add(book);
            }

            return books;
        }
    }
}