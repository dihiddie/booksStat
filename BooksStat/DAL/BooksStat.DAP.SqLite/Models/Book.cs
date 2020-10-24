using System;
using SQLite;

namespace BooksStat.DAP.SqLite.Models
{
    [Table("Book")]
    public class Book
    {
        [PrimaryKey][AutoIncrement][Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
