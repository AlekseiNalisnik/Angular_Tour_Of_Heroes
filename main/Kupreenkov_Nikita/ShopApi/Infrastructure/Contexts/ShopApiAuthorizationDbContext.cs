using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopApi.Infrastructure.Entities;

namespace ShopApi.Infrastructure.Contexts
{
    public class ShopApiAuthorizationDbContext : ApiAuthorizationDbContext<User, UserRole, Guid>
    {
        public ShopApiAuthorizationDbContext(DbContextOptions options,
                                         IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        { }
    }
}