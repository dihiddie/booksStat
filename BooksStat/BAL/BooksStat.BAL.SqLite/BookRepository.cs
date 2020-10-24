using System.Collections.Generic;
using BooksStat.BAL.Core.Interfaces;
using BooksStat.BAL.Core.Models;
using BooksStat.DAP.SqLite.Models;
using SQLite;
using Rating = BooksStat.BAL.Core.Enums.Rating;
using Status = BooksStat.BAL.Core.Enums.Status;

namespace BooksStat.BAL.SqLite
{
    using System;

    using Book = BooksStat.BAL.Core.Models.Book;

    public class BookRepository : IBookRepository
    {
        private readonly SQLiteConnection database;

        public BookRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            CreateTableIfNotExists();
        }

        public bool AddOrUpdate(Book book)
        {
            var dbBook = new DAP.SqLite.Models.Book
                             {
                                 Id = book.Id,
                                 AuthorName = book.AuthorName,
                                 Name = book.BookName,
                                 CreateDateTime = DateTime.Now,
                                 UpdateDateTime = DateTime.Now
                             };
            try
            {
                if (dbBook.Id != 0) database.Update(dbBook);
                else database.Insert(dbBook);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetStatus(int id, Status status)
        {
            var bookStatusLink = GetBookStatusLink(id);
            if (bookStatusLink == null) database.Insert(new BookStatusLink { BookId = id, StatusId = (int)status });
            else
            {
                bookStatusLink.StatusId = (int)status;
                database.Insert(bookStatusLink);
            }
        }

        public void SetRate(int id, Rating rating)
        {
            var bookRatingLink = GetBookRatingLink(id);
            if (bookRatingLink == null) database.Insert(new BookStatusLink { BookId = id, StatusId = (int)rating });
            else
            {
                bookRatingLink.RatingId = (int)rating;
                database.Insert(bookRatingLink);
            }
        }

        public IEnumerable<Book> GetLastUpdates() => database.Table<Book>().ToList();

        public IEnumerable<Book> Search(string searchText, OrderBy order) => throw new System.NotImplementedException();

        public IEnumerable<Book> GetByStatus(Status status, OrderBy order) => throw new System.NotImplementedException();

        private void CreateTableIfNotExists()
        {
            database.CreateTable<Book>();
            database.CreateTable<DAP.SqLite.Models.Status>();
            database.CreateTable<BookStatusLink>();
            database.CreateTable<DAP.SqLite.Models.Rating>();
            database.CreateTable<BookRatingLink>();
        }

        private BookStatusLink GetBookStatusLink(int bookId) => database.Table<BookStatusLink>().FirstOrDefault(x => x.BookId == bookId);

        private BookRatingLink GetBookRatingLink(int bookId) => database.Table<BookRatingLink>().FirstOrDefault(x => x.BookId == bookId);
    }
}