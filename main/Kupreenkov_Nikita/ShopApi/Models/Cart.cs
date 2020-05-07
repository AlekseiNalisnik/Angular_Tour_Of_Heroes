using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        
        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }
        
        public double Cost { get; set; }
        
        public List<CartItem> CartItems { get; set; }
        public User.User User { get; set; }
        public Order Order { get; set; }
    }
}