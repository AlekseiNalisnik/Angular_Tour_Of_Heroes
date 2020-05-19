using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ShopApi.Infrastructure.Entities.CartAggregate
{
    public class Cart : BaseEntity
    {
        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        
        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }

        public double Cost => CartItems.Sum(c => c.Cost);

        public List<CartItem> CartItems { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }

    }
}