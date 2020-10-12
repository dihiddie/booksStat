using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SQLite;

namespace BooksStat.DAP.SqLite.Models
{
    [SQLite.Table("BookRatingLink")]
    public class BookRatingLink
    {
        [PrimaryKey, AutoIncrement, SQLite.Column("Id")]
        public int Id { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; }

        [ForeignKey(nameof(Rating))]
        public int RatingId { get; set; }

        public Rating Rating { get; set; }
    }
}
