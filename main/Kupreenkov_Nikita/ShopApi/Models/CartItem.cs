using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class CartItem
    {
        public long Id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public long UserCartId { get; set; }
        
        [Required]
        [ForeignKey("ShopItem")]
        public long ShopItemId { get; set; }
        
        [System.ComponentModel.DefaultValue(1)] 
        public long ShopItemCount { get; set; }
        
        public virtual User.User User { get; set; }
        public virtual Product.Product Product { get; set; }
    }
}