using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class UserCart
    {
        public long Id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }

        public double Cost { get; set; }
        
        public virtual User.User User { get; set; }
    }
}