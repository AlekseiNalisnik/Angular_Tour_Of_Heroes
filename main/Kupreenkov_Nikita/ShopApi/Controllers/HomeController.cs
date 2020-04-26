using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Authorize]
        public IActionResult Index()
        {
            Console.WriteLine("Login");
            return Content(User.Identity.Name);
        }
    }
}