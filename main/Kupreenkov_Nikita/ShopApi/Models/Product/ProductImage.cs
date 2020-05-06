using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models.Product
{
    public class ProductImage
    {
        public long Id { get; set; }
        
        [Required]
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        
        [Required]
        public byte[] Image { get; set; }
        
        public virtual Product Product { get; set; }
    }
}