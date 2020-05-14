using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using API_Shop_ref.Data;
using API_Shop_ref.Models;
using Microsoft.AspNetCore.Identity;
using API_Shop_ref.ViewModels;
using System.Security.Claims;
using System.Collections.Generic;

namespace API_Shop_ref.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    { /// <summary>
      ///  
      ///  
      ///  
      /// </summary>

        private readonly DBContext _context;
      
        public const string SessionKeyName = "cart";

        public CartsController(DBContext context)
        {
            _context = context;
           

        }

        // POST: api/carts [Создание карзины]
        // 
        [HttpPost]
        public async Task<ActionResult<Carts>> AddCart([FromBody]Carts cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddCart", new { id = cart.Id }, cart);
        }

        // PUT: api/carts/{id} [Изменение корзины]
        // 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Carts cart)
        {
            if (id != cart.Id) { return BadRequest(); }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id)) { return NotFound(); }
                else { throw; }
            }

            return NoContent();
        }

        // DELETE: api/carts/{id} [Удаление карзины]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carts>> DeleteUserCart(int id)
        {
            var Cart = await _context.Carts.FindAsync(id);
            if (Cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(Cart);
            await _context.SaveChangesAsync();

            return Cart;
        }

        
        //===================================== 
        // создать корзину для пользователя
        [HttpPost]   
        // route ?
        public async Task<ActionResult<Carts>> CreateCart([FromQuery]int UserId)
        {
            
            if (User.Identity.IsAuthenticated) 
            {// UserId = UserId
                var carts = new Carts { UserId = UserId };
                _context.Carts.Add(carts);
                await _context.SaveChangesAsync();
                return carts;
            }
            else
            {// SessionId = UserId  
                var carts = new Carts { UserId = int.Parse(HttpContext.Session.Id) }; // ошибка ! проверить 
                _context.Carts.Add(carts);
                await _context.SaveChangesAsync();
                return carts;
            }          
        }


        //добавить предмет в корзину
        [HttpPost]
        // route ?
        public async Task<ActionResult<CartLine>> AddItemToCart([FromQuery]int userID, [FromQuery]int ProductId)
        {
            var cart = await _context.Carts.FindAsync(userID); // находим корзину user
            var cartId = cart.Id;                              // извлекаем Id корзины
            var cartline = new CartLine {ProductId = ProductId, CartId = cartId, Count = 1 }; // добавляем новую запись в CartLine
            _context.CartLine.Add(cartline);
            await _context.SaveChangesAsync();  // сохраняем в БД
         
            return cartline;
        }

        //удалить предмет из корзины
        [HttpDelete]
        // route ?
        public async Task<ActionResult<CartLine>> DeleteItemToCart([FromQuery]int userID, [FromQuery]int ProductId)
        {

            var cart = await _context.Carts.FindAsync(userID);  // находим корзину user
            var cartline = await _context.CartLine.FindAsync(cart.Id, ProductId); // находим запись в CartLine
             _context.CartLine.Remove(cartline); // удаляем запись в CartLine
            await _context.SaveChangesAsync(); // сохраняем изменения в БД

            return cartline;
        }


        //увеличить колличества товара в корзине
        [HttpPut]
        // route ?
        public async Task<ActionResult<CartLine>> IncreaseCountItemToCart([FromQuery]int userID, [FromQuery]int ProductId, [FromQuery]int count)
        {
            var cart = await _context.Carts.FindAsync(userID);  // находим корзину user
            var cartline = await _context.CartLine.FindAsync(cart.Id, ProductId); // находим запись в CartLine

            cartline.Count += count;
            _context.Entry(cartline).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cartline;
        }

        //уменьшить колличество товара в корзине
        [HttpPut]
        // route ?
        public async Task<ActionResult<CartLine>> ReduceCountItemToCart([FromQuery]int userID, [FromQuery]int ProductId, [FromQuery]int count)
        {
            var cartline = await _context.CartLine.FindAsync(userID, ProductId);
            var checkCount = cartline.Count - count;

            if (checkCount <= 0) 
            {
                _context.CartLine.Remove(cartline);
                
            } 
            else 
            { 
                cartline.Count -= count;
                _context.Entry(cartline).State = EntityState.Modified;
                
            }  

           await _context.SaveChangesAsync();
            return cartline;
        }


        //получить корзину пользователя          проверить !
        [HttpGet]
        public async Task<IEnumerable<Carts>> GetCart([FromQuery]int UserId)
        {
            return await _context.Carts.Where(a => a.UserId == UserId) .Include("CartLine.Products") .ToListAsync(); 
        }

        
     /*
        // расчет стоимости карзины
        public async Task<IEnumerable<Carts>> TotalPrice([FromQuery]int UserId)
        {
            var cart = await _context.Carts.FindAsync(UserId); // находим корзину user
            var cartline = await _context.CartLine.Where(b => b.CartId == cart.Id).ToListAsync(); // отбираем все прдукты, относящиеся к этой корзине

            

            return ;
        }


       
            
            
            decimal? total = decimal.Zero;
            total = (decimal?)(from CartLine in _context.CartLine
                               where cartItems.CartId == cart.Id
                               select (int?)CartLine.Count *
                               cartItems.Product.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }

    */

        // проверка наличия карзины в базе
        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}