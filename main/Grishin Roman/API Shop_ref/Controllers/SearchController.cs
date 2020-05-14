using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using API_Shop_ref.Data;
using API_Shop_ref.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly DBContext _context;
       

        public SearchController(DBContext context)
        {
            _context = context;
           
        }

        [HttpGet]
        public ActionResult<List<Products>> Get([FromQuery] string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                return Ok(_context.Products.Where(p => p.ProductName.Contains(query)).ToList());
            }
            return NotFound();
        }
    }
}