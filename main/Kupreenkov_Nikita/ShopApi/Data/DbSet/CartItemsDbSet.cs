using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopApi.Models;

namespace ShopApi.Data.DbSet
{
    public class CartItemsDbSet : DbSet<CartItem>
    {
        public override EntityEntry<CartItem> Add(CartItem entity)
        {
            var existed = Find(entity.Id);
            if (existed != null)
            {
                existed.Count += entity.Count;
                return Update(existed);
            }
            return base.Add(entity);
        }
        
        public override EntityEntry<CartItem> Remove(CartItem entity)
        {
            var existed = Find(entity.Id);
            if (existed != null && existed.Count > entity.Count)
            {
                existed.Count -= entity.Count;
                return Update(existed);
            }
            return base.Remove(entity);
        
        }
    }
}