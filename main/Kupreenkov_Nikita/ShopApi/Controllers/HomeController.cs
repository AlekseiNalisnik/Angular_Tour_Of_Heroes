using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

using ShopApi.Services;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public HomeController(CartRepositoryFactory factory)
        {
            _repository = factory.GetRepository();
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