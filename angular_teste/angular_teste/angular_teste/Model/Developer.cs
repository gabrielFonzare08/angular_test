

using System.ComponentModel.DataAnnotations.Schema;

namespace angular_teste.Model
{
    [Table("developer")]
    public class Developer
    {
        [Column ("id")]
        public long ID { get; set; }
        [Column ("name")]
        public string name { get; set; }
        [Column("avatar")]
        public string avatar { get; set; }

    }
}
