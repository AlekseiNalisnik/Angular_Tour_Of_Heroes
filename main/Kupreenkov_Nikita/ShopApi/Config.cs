using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace ShopApi
{
    public static class Config
    {
       public static IEnumerable<ApiResource> Apis =>
           new List<ApiResource>
           {
               new ApiResource
               {
                   Name = "api"
               }
           };
       
       public static IEnumerable<Client> Clients =>
           new List<Client>
           {
               new Client
               {
                   ClientId = "client",
                   AllowedGrantTypes = new[] { OidcConstants.GrantTypes.ClientCredentials },
                   ClientSecrets =
                   {
                       new Secret
                       {
                           Value = "secret".Sha256()
                       }
                   },
                   AllowedScopes = { "api" }
               }
           };
    }
}