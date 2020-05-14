using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        
        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        
        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }

        public double Cost => CartItems.Sum(c => c.Cost);

        public List<CartItem> CartItems { get; set; }
        public User.User User { get; set; }
        public Order Order { get; set; }

    }
}