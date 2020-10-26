namespace BooksStat.BAL.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string SelectedRating { get; set; }

        public string SelectedStatus { get; set; }
    }
}