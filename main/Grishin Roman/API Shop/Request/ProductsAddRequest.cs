using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Request
{
    public class ProductsAddRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
