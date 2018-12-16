using ASmaple.Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace ASample.Permission.Service.Models
{
    public class IdentityUser : AggregateRoot, IUser<Guid>
    {
        public string UserName { get ; set ; }

        public string PasswordHash { get; set; }

        public IEnumerable<IdentityUserLoginInfo> LoginInfos { get; set; }
    }
}