using System.Threading.Tasks;
using ShopApi.Infrastructure.Interfaces;

namespace ShopApi.Infrastructure.Services
{
    public class RepositoryMapper
    {
        private readonly ICartRepository _input;
        private readonly ICartRepository _output;
        
        public RepositoryMapper(CartRepositoryFactory factory, 
                                ICartRepository output)
        {
            _input = factory.Get();
            _output = output;
        }

        public async Task Map()
        {
            await _output.Add(_input.Get());
        }

    }
}