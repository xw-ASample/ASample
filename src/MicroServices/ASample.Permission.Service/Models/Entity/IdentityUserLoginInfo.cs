 using ASmaple.Domain.Models;
using System;

namespace ASample.Permission.Service.Models
{
    public class IdentityUserLoginInfo : Entity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public Guid UserId { get; set; }
    }
}