using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Interfaces;
using ShopApi.Domain.Services;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Services;

namespace ShopApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private readonly ICartUseCase _useCase;

        public HomeController(CartUseCaseFactory factory)
        {
            _useCase = factory.Get();
        }
        
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok(new
            {
                id = HttpContext.Session.Id, 
                name = User.Identity.Name,
                auth = User.Identity.IsAuthenticated,
                cart = _useCase.Get()
            });
        }
    }
}