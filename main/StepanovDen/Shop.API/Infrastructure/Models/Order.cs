using System.Collections.Generic;
using System.Linq;

namespace Shop.API.Infrastructure.Models
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
        public float TotalPrice => OrderProducts.Sum(op => op.TotalPrice);
        public float TotalWeight => OrderProducts.Sum(op => op.TotalWeight);
        
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}