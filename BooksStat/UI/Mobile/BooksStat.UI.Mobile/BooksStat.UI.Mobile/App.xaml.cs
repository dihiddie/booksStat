using BooksStat.UI.Mobile.Services;
using BooksStat.UI.Mobile.Views;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile
{
    using System;
    using System.IO;
    using BooksStat.BAL.SqLite;

    public partial class App : Application
    {
        private const string ApplicationFolder = "BooksStat";

        private const string DatabaseName = "books.db";

        private static BookRepository bookRepository;

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Brush_Experimental" });

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<BookRepository>();
            MainPage = new NavigationPage(new MainPage());
        }

        public static BookRepository BookRepository =>
            bookRepository ?? (bookRepository = new BookRepository(
                                   Path.Combine(
                                       Environment.GetFolderPath(
                                           Environment.SpecialFolder.LocalApplicationData),
                                       DatabaseName)));

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
