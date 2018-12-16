using ASample.Permission.Service.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Permission.Service.Infrastructure
{
    public class ASamplePermissionUserManager : UserManager<IdentityUser, Guid>
    {

        public ASamplePermissionUserManager(ASamplePermissionUserStore store)
            : base(store)
        {
            Store = store;
        }
        public override bool SupportsUserTwoFactor => false;

        //public ASamplePermissionUserStore Store { get; set; }

        public override async Task<IdentityResult> UpdateAsync(IdentityUser user)
        {
            await Store.UpdateAsync(user);
            return new IdentityResult() { };
        }
    }
}