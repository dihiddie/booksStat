using BooksStat.UI.Mobile.Models;

namespace BooksStat.UI.Mobile.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }

        public Item Item { get; set; }
    }
}