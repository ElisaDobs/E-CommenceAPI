using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommenceAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("UserEmail")]
        public string UserEmail { get; set; }
        [Column("UserPassword")]
        public string UserPassword { get; set; }
        [Column("UserGuid")]
        public Guid UserGuid { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("DateCreated")]
        public DateTime DateCreated { get; set;}
    }
}
