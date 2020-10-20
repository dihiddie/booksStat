using BooksStat.UI.Mobile.Services;
using BooksStat.UI.Mobile.Views;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile
{
    using BooksStat.BAL.SqLite;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Brush_Experimental" });

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<BookRepository>();
            MainPage = new NavigationPage(new MainPage());
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
