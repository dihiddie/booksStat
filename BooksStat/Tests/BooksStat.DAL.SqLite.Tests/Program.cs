namespace BooksStat.DAL.SqLite.Tests
{
    using System;
    using System.IO;

    using BooksStat.BAL.Core.Enums;
    using BooksStat.BAL.Core.Models;
    using BooksStat.BAL.SqLite;

    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "books_test.db");
            var bookRepo = new BookRepository(path);

            var book = new Book
                           {
                               AuthorName = "TestAuthor_1",
                               BookName = "TestBook",
                               SelectedRating = "5",
                               SelectedStatus = "Прочитано"
                           };

            var id = bookRepo.AddOrUpdate(book);
            bookRepo.SetStatus(id, Status.Added);
            bookRepo.SetRate(id, Rating.Four);

            var books = bookRepo.GetLastUpdates();
            Console.WriteLine("Hello World!");
        }
    }
}
