using System.ComponentModel;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile.Views
{
    using System;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // booksListView.ItemsSource = App.BookRepository.GetLastUpdates();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}