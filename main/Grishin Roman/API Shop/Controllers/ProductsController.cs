using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API_Shop.Models;
using API_Shop.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

namespace API_v1.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IQueryable<ProductsAddRequest> products;
        private DBContext db = new DBContext();
        public ProductsController() { }


        // POST: api/products
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductsAddRequest request)
        {
            Products product = new Products { ProductName = request.ProductName, Price = request.Price, Stock = request.Stock, Description = request.Description, Picture = request.Picture };
            using (var db = new DBContext())
            {
                db.Products.Add(product);
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return Ok(product);
                }
                else
                {
                    return BadRequest("Сhanges not saved!");
                }
            }
        }
/*
        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Products, ProductsAddRequest>> AsProductDto =
            x => new ProductsAddRequest

            {
                ProductName = x.ProductName,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                Picture = x.Picture
            };


        // GET api/Books
        [HttpGet]
        public IQueryable<ProductsAddRequest> GetBooks()
        {
            return db.Products.Include(b => b.ProductName).Select(AsProductDto);
        }



        // GET: api/products
        // [HttpGet]
        //  public IActionResult GetProduct(IQueryable<ProductsAddRequest> requests)
        //  { return Ok; 
        //  }

        /*using (var db = new DBContext()) 
       // {
            var books = from b in db.Products
                        select new ProductsAddRequest()
                        {
                            ProductName = b.ProductName,
                            Price = b.Price,
                            Stock = b.Stock,
                            Description = b.Description,
                            Picture = b.Picture
                        };
        //     };


}
     } */
    }
}


