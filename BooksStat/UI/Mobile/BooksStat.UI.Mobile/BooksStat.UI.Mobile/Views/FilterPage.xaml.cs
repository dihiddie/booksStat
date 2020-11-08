using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksStat.UI.Mobile.Views
{
    using System;
    using System.Globalization;
    using System.Linq;

    using BooksStat.BAL.Core.Enums;
    using BooksStat.Utils.Enum;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();

            statusPicker.ItemsSource = EnumExtensions.GetEnumAsList<Status>().ToList();
            ratingPicker.ItemsSource = EnumExtensions.GetEnumAsList<Rating>().ToList();
            monthPicker.ItemsSource = DateTimeFormatInfo.CurrentInfo?.MonthNames.Where(x => !string.IsNullOrEmpty(x)).ToList();
            yearPicker.ItemsSource = App.BookRepository.GetEnteredYears().ToList();
        }

        private void Cancel_OnClicked(object sender, EventArgs e)
        {
            statusPicker.SelectedItem = null;
            ratingPicker.SelectedItem = null;
            monthPicker.SelectedItem = null;
            yearPicker.SelectedItem = null;
            booksListView.ItemsSource = null;
            favoriteCheckBox.IsChecked = false;
        }

        private void Filter_OnClicked(object sender, EventArgs e)
        {
            var selectedStatus = statusPicker.SelectedItem?.ToString();
            Status? statusEnum = null;
            if (!string.IsNullOrEmpty(selectedStatus))
                statusEnum = EnumExtensions.GetValueFromDescription<Status>(selectedStatus);

            var selectedRating = ratingPicker.SelectedItem?.ToString();
            Rating? ratingEnum = null;
            if (!string.IsNullOrEmpty(selectedRating))
                ratingEnum = EnumExtensions.GetValueFromDescription<Rating>(selectedRating);

            int? selectedMonth = null;
            if (!string.IsNullOrEmpty(monthPicker.SelectedItem?.ToString()))
                selectedMonth = DateTime.ParseExact(
                    monthPicker.SelectedItem.ToString(),
                    "MMMM",
                    CultureInfo.CurrentCulture).Month;

            int? selectedYear = null;
            if (!string.IsNullOrEmpty(yearPicker.SelectedItem?.ToString()))
                selectedYear = (int)yearPicker.SelectedItem;

            bool? isFavorite = null;
            if (favoriteCheckBox.IsChecked) isFavorite = true;

            booksListView.ItemsSource = App.BookRepository.Filter(
                statusEnum,
                ratingEnum,
                selectedMonth,
                selectedYear,
                isFavorite);
        }
    }
}