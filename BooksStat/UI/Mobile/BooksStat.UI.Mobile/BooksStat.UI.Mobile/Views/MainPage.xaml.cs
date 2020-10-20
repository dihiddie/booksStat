using System.ComponentModel;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile.Views
{
    using System;
    using BooksStat.UI.Mobile.ViewModels;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}