namespace Shop.API.Infrastructure.Models
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}