using ASample.Identity.Service.Infrasturatuce.Repository;
using ASample.Identity.Service.Models.User;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ASample.Identity.Service.Infrasturatuce.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            using (IdentityUserRepository _repo = new IdentityUserRepository())
            {
                IdentityUser user = await _repo.FindUser(
                    new UserModel() { UserName = context.UserName, Password = context.Password });
                if (user == null)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect");
                    return;
                }
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}