using System.Threading.Tasks;

namespace ShopApi.Services
{
    public class RepositoryMapper
    {
        private readonly ICartRepository _input;
        private readonly ICartRepository _output;
        
        public RepositoryMapper(CartRepositoryFactory factory, 
                                ICartRepository output)
        {
            _input = factory.GetRepository();
            _output = output;
        }

        public async Task Map()
        {
            await _output.Add(_input.Get());
        }

    }
}