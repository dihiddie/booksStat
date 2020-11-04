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
            var selectedStatus = statusPicker.SelectedItem?.ToString();
            var selectedRating = ratingPicker.SelectedItem?.ToString();

            var bookId = SaveBook(selectedStatus, selectedRating);
            SetStatus(bookId, selectedStatus);
            SetRating(bookId, selectedRating);

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private int SaveBook(string selectedStatus, string selectedRating)
        {
            var book = new Book
                           {
                               AuthorName = authorNameEntry.Text,
                               BookName = bookNameEntry.Text,
                               SelectedStatus = selectedStatus,
                               SelectedRating = selectedRating,
                               IsFavorite = favoriteCheckBox.IsChecked,
                               WhoAdvisedToRead = adviserNameEntry.Text
                           };
            return App.BookRepository.AddOrUpdate(book);
        }

        private void SetStatus(int bookId, string selectedStatus)
        {
            if (string.IsNullOrEmpty(selectedStatus)) return;
            var statusEnum = EnumExtensions.GetValueFromDescription<Status>(selectedStatus);
            App.BookRepository.SetStatus(bookId, statusEnum);
        }

        private void SetRating(int bookId, string selectedRating)
        {
            if (string.IsNullOrEmpty(selectedRating)) return;
            var ratingEnum = EnumExtensions.GetValueFromDescription<Rating>(selectedRating);
            App.BookRepository.SetRate(bookId, ratingEnum);
        }
    }
}