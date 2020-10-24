using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile.Views
{
    using BooksStat.DAP.SqLite.Models;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
            App.BookRepository.AddOrUpdate(
                new Book
                {
                    AuthorName = "111",
                    AuthorLastName = "123",
                    Name = "111",
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                });
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }
    }
}