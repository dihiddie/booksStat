using BooksStat.BAL.Core.Interfaces;
using BooksStat.BAL.SqLite;
using BooksStat.UI.Mobile.Views;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IBookRepository, BookRepository>();

            //if (UseMockDataStore)
            //    DependencyService.Register<MockDataStore>();
            //else
            //    DependencyService.Register<AzureDataStore>();
            MainPage = new MainPage();
        }

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
