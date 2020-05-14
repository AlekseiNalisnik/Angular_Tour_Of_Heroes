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
using System.Collections;

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
        // создать корзину для пользователя
        [HttpPost]
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


        //добавить предмет в корзину [добавить новую запись в CartLine]
        [HttpPost]
        // route ?
        public async Task<ActionResult<CartLine>> AddItemToCart([FromQuery]int userID, [FromQuery]int ProductId)
        {
            var cart = await _context.Carts.FindAsync(userID); // находим корзину user
            var cartId = cart.Id;                              // извлекаем Id корзины
            var cartline = new CartLine { ProductId = ProductId, CartId = cartId, Count = 1 }; // добавляем новую запись в CartLine
            _context.CartLine.Add(cartline);
            await _context.SaveChangesAsync();  // сохраняем в БД

            return cartline;
        }

        //удалить предмет из корзины [удалить запись из CartLine]
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


        //увеличить колличества товара в корзине [изменить запись в CartLine + count]
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

        //уменьшить колличество товара в корзине [изменить запись в CartLine - count]
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
            return await _context.Carts.Where(a => a.UserId == UserId).Include("CartLine.Products").ToListAsync();
        }

      

    

        // проверка наличия карзины в базе
        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}