namespace API_Shop_ref.Infrastructure.Repository
{
    public interface ICartRepository
    {
        int AddCartToDB(int userId);
        int GetUserCartId(int userID);
        int AddItem(int ProductId, int CartId, int Count);
        void DeleteItem(int cartLineId);
        int FindCartlineId(int cartId, int productId);
        int FindCartlineCount(int cartLineId);
        void UpdateCartLine(int cartLineId, int cartLineCount);
        
    }
}
