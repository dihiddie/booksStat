namespace BooksStat.DAL.SqLite.Models
{
    using SQLite;

    using SQLiteNetExtensions.Attributes;

    [Table(nameof(BookStatusLink))]
    public class BookStatusLink
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey(typeof(Book))]
        public int BookId { get; set; }

        [ForeignKey(typeof(Status))]
        public int StatusId { get; set; }
    }
}
