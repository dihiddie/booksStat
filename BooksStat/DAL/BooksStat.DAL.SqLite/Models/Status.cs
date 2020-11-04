namespace BooksStat.DAL.SqLite.Models
{
    using SQLite;

    [Table(nameof(Status))]
    public class Status
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
