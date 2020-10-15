using SQLite;

namespace BooksStat.DAP.SqLite.Models
{
    [Table("Status")]

    public class Status
    {
        [PrimaryKey][AutoIncrement][Column("Id")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
