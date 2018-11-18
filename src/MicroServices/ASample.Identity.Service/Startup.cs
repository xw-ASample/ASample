using System;
using System.Threading.Tasks;
using System.Web.Http;
using ASample.Identity.Service.Infrasturatuce;
using ASample.Identity.Service.Infrasturatuce.Model;
using ASample.Identity.Service.Infrasturatuce.Provider;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(ASample.Identity.Service.Startup))]

namespace ASample.Identity.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            ConfigAuth(app);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
        }

        public void ConfigAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<IdentityContext>(() => new IdentityContext());
            //app.CreatePerOwinContext<UserManager<AppUser>>(
            //(o, c) => new UserManager<AppUser>(new UserStore<AppUser>(
            //c.Get<IdentityContext>())));
            //app.CreatePerOwinContext<RoleManager<IdentityRole>>(
            //(o, c) => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(
            //c.Get<IdentityContext>())));

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

        }
    }
}
