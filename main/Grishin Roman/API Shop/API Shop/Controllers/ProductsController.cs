using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Shop.Models;
using API_Shop.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

namespace API_v1.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {        
        public ProductsController() {}

        // POST: api/products
       [HttpPost]
        public IActionResult AddItem([FromBody] ProductsAddRequest request)
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

        // GET: api/products
       // [HttpGet]
      //  public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
      //  {
      //      return await _context.Orders.ToListAsync();
      //  }
        
    }
}