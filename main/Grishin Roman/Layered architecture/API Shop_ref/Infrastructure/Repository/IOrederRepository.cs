namespace API_Shop_ref.Infrastructure.Repository
{
    public interface IOrederRepository
    {
        int AddOrder(int cartId, decimal price);
        decimal Calculate(int cartId);
    }
}
