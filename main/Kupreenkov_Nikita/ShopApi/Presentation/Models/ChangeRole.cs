using System;
using System.Collections.Generic;
using ShopApi.Infrastructure.Models;

namespace ShopApi.Presentation.Models
{
    public class ChangeRole
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public IEnumerable<string> UserRoles  { get; set; }
        public IEnumerable<UserRole> AllRoles  { get; set; }
    }
}