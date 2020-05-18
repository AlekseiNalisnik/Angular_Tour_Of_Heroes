using System;
using System.Linq;
using API_Shop_ref.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Shop_ref.Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DBContext _context;

        public CartRepository(DBContext context)
        {
            _context = context;
        }

        public int AddCartToDB(int userId)
        {
            var carts = new Carts { UserId = userId }; 
            _context.Carts.Add(carts);
            _context.SaveChanges();
            var NewCartId = carts.Id;   //??
            return NewCartId;           //??
        }

        public int GetUserCartId(int userId)
        {           
            var cart = _context.Carts.Where(p => p.UserId == userId).FirstOrDefault();
            var cartId = cart.Id;
            return cartId;
        }

        public int AddItem(int ProductId, int CartId, int Count)
        {
            var cart = new CartLine { ProductId = ProductId, CartId = CartId, Count = Count };
            _context.CartLine.Add(cart);
            _context.SaveChanges();
            var NewCartLineID = cart.Id;  // ??
            return NewCartLineID;         // ??
        }

        public void DeleteItem(int cartLineId)
        {
            var cart = _context.CartLine.Find(cartLineId);
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            _context.CartLine.Remove(cart);
            _context.SaveChanges();
        }
        public int FindCartlineId(int cartId, int productId)
        {
            var cartline = _context.CartLine
                                 .Where(op => op.CartId == cartId)
                                 .SingleOrDefault(op => op.ProductId == productId);

            var cartLineId = cartline.Id;
            return cartLineId;
        }
        public int FindCartlineCount(int cartLineId)
        {
            var cartLine = _context.CartLine.Find(cartLineId);
            var cartLineCount = cartLine.Count;
            return cartLineCount;
        }

        public void UpdateCartLine(int cartLineId, int cartLineCount)
        {
            var cartline = _context.CartLine.Find(cartLineId);
            cartline.Count = cartLineCount;
            _context.Entry(cartline).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}