using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommenceAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("ProductId")]
        public int ProductId { get; set; }
        [Column("ProductName")]
        public string ProductName { get; set; }
        [Column("ProductImage")]
        public string ProductImage { get; set; }
        [Column("ProductPrice")]
        public decimal ProductPrice { get; set; }
        [Column("ProductQuantity")]
        public int ProductQuantity { get; set; }
        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }
        [ForeignKey("Users")]
        [Column("CreatedBy_UserId")]
        public int CreatedBy_UserId { get; set; }
    }
}
