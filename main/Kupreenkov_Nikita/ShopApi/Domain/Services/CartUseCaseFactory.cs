using System;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using ShopApi.Domain.Interfaces;
using ShopApi.Domain.UseCases.CartAggregate;

namespace ShopApi.Domain.Services
{
    public class CartUseCaseFactory
    {
        private readonly IServiceProvider _provider;
        private readonly IHttpContextAccessor _accessor;

        public CartUseCaseFactory(IServiceProvider provider, 
                                  IHttpContextAccessor accessor)
        {
            _provider = provider;
            _accessor = accessor;
        }
           
        public ICartUseCase Get()
        {
            if(_accessor.HttpContext.User.Identity.IsAuthenticated)
                return (ICartUseCase) _provider.GetRequiredService(typeof(AuthorizedCartUseCase));
        
            return (ICartUseCase) _provider.GetRequiredService(typeof(UnauthorizedCartUseCase));
        } 
    }
}