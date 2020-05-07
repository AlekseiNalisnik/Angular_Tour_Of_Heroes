using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using ShopApi.Data;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;

        public HomeController(ShopDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        
        [Route("Index")]
        public IActionResult Index()
        {
            var sessionCart = _cache.GetString(HttpContext.Session.Id);
            return Ok(new
            {
                id = HttpContext.Session.Id, 
                name = User.Identity.Name,
                cart = JsonConvert.DeserializeObject<Dictionary<string, long>>(sessionCart)
            });
        }
    }
}