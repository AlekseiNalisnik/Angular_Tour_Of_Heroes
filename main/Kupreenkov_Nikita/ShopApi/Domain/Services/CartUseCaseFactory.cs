using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using ShopApi.Domain.UseCases.CartAggregate;
using ShopApi.Properties;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Repositories;

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
           
        public ICartRepository Get()
        {
            if(_accessor.HttpContext.User.Identity.IsAuthenticated)
                return (ICartRepository) _provider.GetRequiredService(typeof(AuthorizedCartUseCase));
        
            return (ICartRepository) _provider.GetRequiredService(typeof(UnauthorizedCartUseCase));
        } 
    }
}