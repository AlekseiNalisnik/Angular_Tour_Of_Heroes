using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApi.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        void Create(T item);
        void Update(T item);
        public Task Delete(T item);
    }
}