namespace BooksStat.DAL.SqLite.Models
{
    using SQLite;

    [Table(nameof(Rating))]
    public class Rating
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
