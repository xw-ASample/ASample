using ASample.Permission.Service.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Permission.Service.Infrastructure
{
    public class ASamplePermissionSignInManage :SignInManager<IdentityUser, Guid>
    {
        public ASamplePermissionSignInManage(ASamplePermissionUserManager userManager)
           : base(userManager, OwinContextHelper.CurrentOwinContext.Authentication)
        {

        }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        {
            var userIdentity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}