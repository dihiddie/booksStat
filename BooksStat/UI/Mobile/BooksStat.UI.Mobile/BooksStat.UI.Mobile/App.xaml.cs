using BooksStat.UI.Mobile.Services;
using BooksStat.UI.Mobile.Views;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
