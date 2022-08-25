using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommenceAPI.Models
{
    [Table("ProductOrder")]
    public class ProductOrder
    {
        [Key]
        [Column("OrderId")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        [Column("ProductId")]
        public int ProductId { get; set; }
        [Column("OrderNo")]
        public string OrderNo { get; set; }
        [ForeignKey("Users")]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("OrderSequence")]
        public int OrderSequence { get; set; }
        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }
    }
}
