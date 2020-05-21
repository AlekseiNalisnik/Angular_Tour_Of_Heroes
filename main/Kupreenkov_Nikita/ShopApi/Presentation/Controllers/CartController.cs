using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

using ShopApi.Infrastructure.Contexts;

namespace ShopApi.Presentation.Controllers
{
 
    namespace ShopApi.Presentation.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CartController : ControllerBase
        {
            private readonly ShopDbContext _context;
            private readonly IDistributedCache _cache;

            public CartController(ShopDbContext context, 
                                  IDistributedCache cache)
            {
                _context = context;
                _cache = cache;
            }
            
            [HttpGet("[action]")]
            public async Task<IActionResult> Checkout()
            {
                return Ok();
            }
        }
    }
}