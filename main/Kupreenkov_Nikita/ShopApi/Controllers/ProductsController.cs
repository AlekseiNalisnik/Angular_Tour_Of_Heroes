using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

using ShopApi.Data;
using ShopApi.Data.DbSet;
using ShopApi.Models;
using ShopApi.Models.Product;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;
        
        public ProductsController(ShopDbContext context, 
            IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Product>> Get()
        {
            return await _context.Products.Include("Images").ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) { return NotFound(); }

            return product;
        }
        
        [HttpPut("[action]/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> PutCart(Dictionary<string, long> cart)
        {
            await _cache.SetStringAsync(HttpContext.Session.Id, 
                JsonConvert.SerializeObject(cart));
            return Ok();
        }
        
        private async
        Task<Product>
        ActionWithAuthorizedCart(Guid id, 
                                 Guid userid, 
                                 Func<CartItem, 
                                 EntityEntry<CartItem>> action, 
                                 long count = 1)
        {
            var ucc = new UserCartsController(_context);
            var cart = ucc.GetUserCart(userid).Result.First(c => c.OrderId == null);
            var product = await _context.Products.FindAsync(id);
            action.Invoke(new CartItem
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Count = count
            });
            await _context.SaveChangesAsync();
            return product;
        }
        
        [HttpPost("[action]/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> AddToCart(Guid id)
        {
            Dictionary<Guid, long> cart;
            var product = await _context.Products.FindAsync(id);

            try
            {
                cart = JsonConvert.DeserializeObject<Dictionary<Guid, long>>(
                    await _cache.GetStringAsync(HttpContext.Session.Id));

                if (cart.ContainsKey(product.Id))
                    cart[product.Id]++;
                else
                    cart.Add(product.Id, 1);
            }
            catch(ArgumentNullException)
            {
                HttpContext.Session.SetInt32("cart", 1);
                cart = new Dictionary<Guid, long> { { product.Id, 1 } };
            }

            await _cache.SetStringAsync(HttpContext.Session.Id, 
                JsonConvert.SerializeObject(cart));
            
            return product;
        }

        [HttpDelete("[action]/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> DeleteFromCart(Guid id)
        {
            Dictionary<Guid, long> cart;
            
            try
            {
                cart = JsonConvert.DeserializeObject<Dictionary<Guid, long>>(
                    await _cache.GetStringAsync(HttpContext.Session.Id));

                if (cart.ContainsKey(id))
                    cart.Remove(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            
            await _cache.SetStringAsync(HttpContext.Session.Id, 
                JsonConvert.SerializeObject(cart));
            
            return Ok(await _context.Products.FindAsync(id));
        }

        [HttpPost("[action]/{id}/{userId}")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Product>> AddToCart(Guid id, Guid userId)
        {
           return await ActionWithAuthorizedCart(id, userId, _context.CartItems.Add);
        }
        
        [HttpDelete("[action]/{id}/{userId}")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Product>> DeleteFromCart(Guid id, Guid userId) =>
            await ActionWithAuthorizedCart(id, userId, _context.CartItems.Remove);
        
        [HttpPut("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Put(Guid id, Product product)
        {
            if (id != product.Id) { return BadRequest(); }

            _context.Entry(product).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) { return NotFound(); }
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles="Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Product>> Post([FromForm]Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            var shopItem = await _context.Products.FindAsync(id);
            if (shopItem == null) {  return NotFound(); }

            _context.Products.Remove(shopItem);
            await _context.SaveChangesAsync();

            return shopItem;
        }

        private bool ProductExists(Guid id) =>
            _context.Products.Any(e => e.Id == id);
    }
}
