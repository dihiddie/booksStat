using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile.Views
{
    using System.Linq;

    using BooksStat.BAL.Core.Enums;
    using BooksStat.BAL.Core.Models;
    using BooksStat.Utils.Enum;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = this;
            statusPicker.ItemsSource = EnumExtensions.GetEnumAsList<Status>().ToList();
            ratingPicker.ItemsSource = EnumExtensions.GetEnumAsList<Rating>().ToList();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var selectedStatus = statusPicker.SelectedItem.ToString();
            var selectedRating = ratingPicker.SelectedItem.ToString();

            var book = new Book()
                           {
                               AuthorName = authorNameEntry.Text,
                               BookName = bookNameEntry.Text,
                               SelectedStatus = selectedStatus,
                               SelectedRating = selectedRating
            };
            var savedId = App.BookRepository.AddOrUpdate(book);

            var statusEnum = EnumExtensions.GetValueFromDescription<Status>(selectedStatus);
            App.BookRepository.SetStatus(savedId, statusEnum);

            var ratingEnum = EnumExtensions.GetValueFromDescription<Rating>(selectedRating);
            App.BookRepository.SetRate(savedId, ratingEnum);

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }
    }
}