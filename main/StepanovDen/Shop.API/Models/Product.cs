using System.Collections.Generic;

namespace Shop.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}