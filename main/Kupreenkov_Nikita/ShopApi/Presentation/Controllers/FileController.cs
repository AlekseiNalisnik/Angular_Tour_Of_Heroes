using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FileController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public FileController(IDistributedCache cache)
        {
            _cache = cache;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery]string path)
        {
            return Ok(File(path, MediaTypeNames.Image.Jpeg));
        }
    }
}