namespace BooksStat.DAL.SqLite.Models
{
    using SQLite;

    using SQLiteNetExtensions.Attributes;

    [Table(nameof(BookRatingLink))]
    public class BookRatingLink
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey(typeof(Book))]
        public int BookId { get; set; }

        [ForeignKey(typeof(Rating))]
        public int RatingId { get; set; }
    }
}
