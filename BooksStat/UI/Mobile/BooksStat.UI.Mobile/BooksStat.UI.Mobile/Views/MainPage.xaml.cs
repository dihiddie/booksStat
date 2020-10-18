using System.ComponentModel;
using Xamarin.Forms;

namespace BooksStat.UI.Mobile.Views
{
    using System.Collections.Generic;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Phones = new List<Phone>
                         {
                             new Phone { Title = "Galaxy S8", Company = "Samsung", Price = 48000 },
                             new Phone { Title = "Huawei P10", Company = "Huawei", Price = 35000 },
                             new Phone { Title = "HTC U Ultra", Company = "HTC", Price = 42000 },
                             new Phone { Title = "iPhone 7", Company = "Apple", Price = 52000 }
                         };
            phonesListView.ItemsSource = Phones;
        }

        public List<Phone> Phones { get; set; }
    }

    public class Phone
    {
        public string Title { get; set; }

        public string Company { get; set; }

        public int Price { get; set; }
    }
}