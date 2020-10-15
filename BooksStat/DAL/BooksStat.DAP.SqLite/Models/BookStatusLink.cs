using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace BooksStat.DAP.SqLite.Models
{
    [SQLite.Table("BookStatusLink")]
    public class BookStatusLink
    {
        [PrimaryKey][AutoIncrement][SQLite.Column("Id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
