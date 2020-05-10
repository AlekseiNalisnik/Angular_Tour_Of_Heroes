using System;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using ShopApi.Properties;

namespace ShopApi.Services
{
    public class CartRepositoryFactory
    {
        private readonly IServiceProvider _provider;
        private readonly IHttpContextAccessor _accessor;
        private readonly IOptions<RepositoryConfiguration> _option;

        public CartRepositoryFactory(IServiceProvider provider, 
                                     IHttpContextAccessor accessor,
                                     IOptions<RepositoryConfiguration> option)
        {
            _provider = provider;
            _accessor = accessor;
            _option = option;
        }
           
        public ICartRepository GetRepository()
        {
            if(_accessor.HttpContext.User.Identity.IsAuthenticated)
                return (ICartRepository) _provider.GetRequiredService(typeof(AuthorizedDbCartRepository));
        
            if (_option.Value.SessionDbOnly)
                return (ICartRepository) _provider.GetRequiredService(typeof(UnauthorizedDbCartRepository));
            
            return (ICartRepository) _provider.GetRequiredService(typeof(InMemoryCartRepository));
        } 
    }
}