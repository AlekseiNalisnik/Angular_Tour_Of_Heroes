using API_Shop_ref.Infrastructure.Repository;

namespace API_Shop_ref.Domain
{
    public class CartUseCases 
    {

        private readonly ICartRepository _cartRepository;

        public CartUseCases(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;

        }           

        // создать корзину для пользователя      
        public int CreateCart(int userId)
        {
            var newCartId = _cartRepository.AddCartToDB(userId);
            return newCartId;
        }       

        //добавить предмет в корзину [добавить новую запись в CartLine]
        public void AddItemToCart(int userID, int ProductId)
        {
           var cartId = _cartRepository.GetUserCartId(userID); // ID карзины для User       
            _cartRepository.AddItem(ProductId, cartId, 1);     // добавляем новую запись в CartLine                      
        }

        //удалить предмет из корзины [удалить запись из CartLine]      
        public void DeleteItemToCart(int userID, int ProductId)
        {
            var cartId = _cartRepository.GetUserCartId(userID);                  // ID карзины для User
            var cartLineId = _cartRepository.FindCartlineId(cartId, ProductId);  // ID CartLine для User
            _cartRepository.DeleteItem(cartLineId);        
        }


        //увеличить колличества товара в корзине [изменить запись в CartLine + count]        
        public void IncreaseCountItemToCart(int userID, int ProductId,int count)
        {
            var cartId = _cartRepository.GetUserCartId(userID);                 // ID карзины для User
            var cartLineId = _cartRepository.FindCartlineId(cartId, ProductId); // ID CartLine для User
            var cartLineCount =_cartRepository.FindCartlineCount(cartLineId);   // находим количество товара в CartLine

            cartLineCount += count;                                             // меняем значение count
            _cartRepository.UpdateCartLine(cartLineId, cartLineCount);          // обновляем запись
        }

        //уменьшить колличество товара в корзине [изменить запись в CartLine - count]       
        public void ReduceCountItemToCart(int userID, int ProductId, int count)
        {
            var cartId = _cartRepository.GetUserCartId(userID);                 // ID карзины для User
            var cartLineId = _cartRepository.FindCartlineId(cartId, ProductId); // ID CartLine для User
            var cartLineCount = _cartRepository.FindCartlineCount(cartLineId);   // находим количество товара в CartLine
            var checkCount = cartLineCount - count;           

              if (checkCount <= 0)
              {
                _cartRepository.DeleteItem(cartLineId);

              } else{
                    cartLineCount -= count;                                         // меняем значение count
                    _cartRepository.UpdateCartLine(cartLineId, cartLineCount);      // обновляем запись
              }           
        }


        //получить корзину пользователя 
       // public void GetCart(int UserId)
      //  {
            
       // }


        // проверка наличия карзины в базе
      //  private bool CartExists(int id)
      //  {
      //      return _context.Carts.Any(e => e.Id == id);
     //   }


    }
}
