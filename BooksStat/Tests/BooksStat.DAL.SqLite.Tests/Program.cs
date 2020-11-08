namespace BooksStat.DAL.SqLite.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using BooksStat.BAL.Core.Enums;
    using BooksStat.BAL.Core.Models;
    using BooksStat.BAL.SqLite;

    public class Program
    {
        public static void Main(string[] args)
        {
            var month = DateTimeFormatInfo.CurrentInfo?.MonthNames;

            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "books_test.db");
            var bookRepo = new BookRepository(path);

            // SetData(bookRepo);

            var books = bookRepo.GetLastUpdates(500);
            ConsoleWriteLine(books);

            Filter(bookRepo);

            Console.WriteLine("Hello World!");
        }

        private static void SetData(BookRepository bookRepo)
        {
            for (int i = 0; i < 10; i++)
            {
                var id = bookRepo.AddOrUpdate(new Book
                                                  {
                                                      AuthorName = $"TestAuthor_{i}",
                                                      BookName = $"TestBookName_{i}",
                                                      IsFavorite = true
                                                  });
                bookRepo.SetStatus(id, Status.Readed);
                bookRepo.SetRate(id, Rating.Four);
            }

            for (int i = 10; i < 20; i++)
            {
                var id = bookRepo.AddOrUpdate(new Book
                                                  {
                                                      AuthorName = $"TestAuthor_{i}",
                                                      BookName = $"TestBookName_{i}",
                                                  });
                bookRepo.SetStatus(id, Status.WantToRead);
            }

            for (int i = 20; i < 30; i++)
            {
                var id = bookRepo.AddOrUpdate(new Book
                                                  {
                                                      AuthorName = $"TestAuthor_{i}",
                                                      BookName = $"TestBookName_{i}",
                                                  });
                bookRepo.SetStatus(id, Status.NotFinished);
                bookRepo.SetRate(id, Rating.Five);
            }

            for (int i = 30; i < 40; i++)
            {
                var id = bookRepo.AddOrUpdate(new Book
                                                  {
                                                      AuthorName = $"TestAuthor_{i}",
                                                      BookName = $"TestBookName_{i}",
                                                  });
                bookRepo.SetStatus(id, Status.Readed);
                bookRepo.SetRate(id, Rating.Three);
            }
        }

        private static void Filter(BookRepository bookRepo)
        {
            // со статуса
            var filtered = bookRepo.Filter(Status.Readed, null, null, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(Status.Readed, Rating.Four, null, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(Status.Readed, Rating.Three, null, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(Status.Readed, Rating.Four, 11, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(Status.Readed, Rating.Four, 11, 2020, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(Status.Readed, Rating.Four, 11, 2020, true);
            ConsoleWriteLine(filtered);

            // с рейтинга
            filtered = bookRepo.Filter(null, Rating.Five, null, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(null, Rating.Five, null, 2020, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(null, Rating.Five, null, 2020, true);
            ConsoleWriteLine(filtered);

            // с месяца
            filtered = bookRepo.Filter(null, null, 11, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(null, null, 11, 2020, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(null, null, 11, null, true);
            ConsoleWriteLine(filtered);

            // с года
            filtered = bookRepo.Filter(null, null, null, 2020, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(null, null, null, 2020, true);
            ConsoleWriteLine(filtered);

            // с фаворита
            filtered = bookRepo.Filter(null, null, null, null, null);
            ConsoleWriteLine(filtered);

            filtered = bookRepo.Filter(null, null, null, null, true);
            ConsoleWriteLine(filtered);
        }

        private static void ConsoleWriteLine(IEnumerable<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(
                    $"{book.AuthorBookName} - {book.SelectedStatus} - {book.SelectedRating} - {book.IsFavorite}");
        }
    }
}
