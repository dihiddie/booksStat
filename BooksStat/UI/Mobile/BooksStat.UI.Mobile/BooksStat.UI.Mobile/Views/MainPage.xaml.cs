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
            booksListView.ItemsSource = App.BookRepository.GetLastUpdates();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        private void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            booksListView.ItemsSource = App.BookRepository.Search(searchBar.Text);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchBar.Text)) booksListView.ItemsSource = App.BookRepository.GetLastUpdates();
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new FilterPage()));
        }
    }
}