﻿using System;
using System.Collections.Generic;
using System.IO;
using BooksStat.BAL.Core.Interfaces;
using BooksStat.BAL.Core.Models;
using BooksStat.DAP.SqLite.Models;
using Microsoft.Extensions.Logging;
using SQLite;
using Rating = BooksStat.BAL.Core.Enums.Rating;
using Status = BooksStat.BAL.Core.Enums.Status;

namespace BooksStat.BAL.SqLite
{
    public class BookRepository : IBookRepository
    {
        private const string DatabaseName = "books.db";

        private readonly ILogger logger;

        private readonly SQLiteConnection database;

        public BookRepository(ILogger<BookRepository> logger)
        {
            this.logger = logger;
            var databasePath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseName);
            database = new SQLiteConnection(databasePath);
            CreateTableIfNotExists();
        }

        public bool AddOrUpdate(Book book)
        {
            try
            {
                if (book.Id != 0) database.Update(book);
                else database.Insert(book);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetStatus(Book book, Status status) => throw new System.NotImplementedException();

        public void SetRate(Book book, Rating rating) => throw new System.NotImplementedException();

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
    }
}