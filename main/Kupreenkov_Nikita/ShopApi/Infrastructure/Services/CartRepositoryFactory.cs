using System;

using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

using ShopApi.Properties;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Repositories.CartAggregate;

namespace ShopApi.Infrastructure.Services
{
    public class CartRepositoryFactory
    {
        private readonly IServiceProvider _provider;
        private readonly IOptions<RepositoryConfiguration> _option;

        public CartRepositoryFactory(IServiceProvider provider, 
                                     IOptions<RepositoryConfiguration> option)
        {
            _provider = provider;
            _option = option;
        }
           
        public ICartRepository Get()
        {
            if( _option.Value.SessionDbOnly)
                return (ICartRepository) _provider.GetRequiredService(typeof(DbCartRepository));
        
            return (ICartRepository) _provider.GetRequiredService(typeof(InMemoryCartRepository));
        } 
    }
}