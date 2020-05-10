using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using ShopApi.Data;
using ShopApi.Services;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ICartRepository _repository;

        public HomeController(ShopDbContext context, 
                              IDistributedCache cache,
                              ICartRepository repository)
        {
            _context = context;
            _cache = cache;
            _repository = repository;
        }
        
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok(new
            {
                id = HttpContext.Session.Id, 
                name = User.Identity.Name,
                auth = User.Identity.IsAuthenticated,
                cart =  _repository.Get()
            });
        }
    }
}