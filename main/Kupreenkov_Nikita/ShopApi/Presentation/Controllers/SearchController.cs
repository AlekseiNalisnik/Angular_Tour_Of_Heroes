using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities;
using ShopApi.Infrastructure.Entities.ProductAggregate;
using ShopApi.Infrastructure.Models;

namespace ShopApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
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
        public ActionResult<List<Product>> Get([FromQuery] string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                return Ok(_context.Products.Where(p => p.Name.Contains(query)).ToList());
            }
            return NotFound();
        }
    }
}