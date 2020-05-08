using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ShopApi.Data;
using ShopApi.Models.Product;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;
        
        public SearchController(ShopDbContext context,
                                IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<Product>> Get([FromQuery] string query)
        {
            if (!String.IsNullOrEmpty(query))
            {
                return Ok(_context.Products.Where(p => p.Name.Contains(query)).ToList());
            }
            return NotFound();
        }
    }
}