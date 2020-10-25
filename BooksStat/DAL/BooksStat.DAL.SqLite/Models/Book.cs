using System;

namespace BooksStat.DAL.SqLite.Models
{
    using SQLite;

    [Table(nameof(Book))]
    public class Book
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
