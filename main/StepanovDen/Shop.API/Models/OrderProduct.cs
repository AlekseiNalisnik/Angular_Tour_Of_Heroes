using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }

        [NotMapped] 
        public float TotalPrice => Product.Price * ProductQuantity;

        public float TotalWeight => Product.Weight * ProductQuantity;
    }
}