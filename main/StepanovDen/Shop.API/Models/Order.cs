using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Models
{
    public class Order
    {
        public const string SHOPPINGCART = "Shopping Cart";
        public const string CONFIRMED = "Confirmed";

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Status { get; set; } = SHOPPINGCART;
        
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}