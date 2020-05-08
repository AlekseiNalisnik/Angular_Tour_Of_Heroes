using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using ShopApi.Data;
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

        private async
        Task<Product>
        EditCart(Guid id, 
                 Action<CartItem, Product, Cart> atAuthAction, 
                 Action<Product, Dictionary<Guid, long>> atUnAuthAction)
        {
            var product = await _context.Products.FindAsync(id);

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var ucc = new UserCartsController(_context, _cache);
                var userId = Guid.Parse(HttpContext.User.Claims
                    .First(c => c.Type == ClaimTypes.Sid).Value);
                
                var cart = ucc.GetUserCart(userId)
                              .Result.First(c => c.OrderId == null);
                
                var cartItem = _context.CartItems.FirstOrDefault(cI => 
                    cI.ProductId == product.Id && cI.CartId == cart.Id);
                
                atAuthAction.Invoke(cartItem, product, cart);
                await _context.SaveChangesAsync();
            }
            else
            {
                var cart = JsonConvert.DeserializeObject<Dictionary<Guid, long>>(
                    HttpContext.Session.GetString("cart") ?? "{}");
                
                atUnAuthAction.Invoke(product, cart);
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            }

            return product;
        }
        
        [HttpPost("[action]")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Product>> AddToCart([FromQuery]Guid id, [FromQuery]long count = 1)
        {
            return await EditCart(id, 
            (CartItem cartItem, Product product, Cart cart) =>
            {
                if (cartItem == null)
                {
                    _context.CartItems.Add(new CartItem
                    {
                        ProductId = product.Id,
                        CartId = cart.Id,
                        Count = count
                    });
                }
                else
                {
                    cartItem.Count += count;
                    _context.CartItems.Update(cartItem);
                }
            },
            (Product product, Dictionary<Guid, long> cart) =>
            {
                if (cart.ContainsKey(product.Id))
                    cart[product.Id] += count;
                else
                    cart.Add(product.Id, count);
            });
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> DeleteFromCart([FromQuery]Guid id, [FromQuery]long count = 1)
        {
            return await EditCart(id, 
                (CartItem cartItem, 
                Product product, 
                Cart cart) =>
            {
                if (cartItem == null) return;
                cartItem.Count -= count;
                if (cartItem.Count < 1)
                {
                    _context.CartItems.Remove(cartItem);
                    return;
                }
                _context.CartItems.Update(cartItem);
            },
            (Product product, Dictionary<Guid, long> cart) =>
            {
                if (cart.TryGetValue(product.Id, out var _count))
                {
                    _count -= count;
                    if (_count < 1)
                        cart.Remove(product.Id);
                    else
                        cart[product.Id] = _count;
                }
            });
        }

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
