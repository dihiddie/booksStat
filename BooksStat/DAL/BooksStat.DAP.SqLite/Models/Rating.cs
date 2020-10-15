using SQLite;

namespace BooksStat.DAP.SqLite.Models
{
    [Table("Rating")]

    public class Rating
    {
        [PrimaryKey][AutoIncrement][Column("Id")]
        public int Id { get; set; }

        public int Rate { get; set; }
    }
}
