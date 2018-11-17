using System;
using System.Threading.Tasks;
using System.Web.Http;
using ASample.Identity.Service.Infrasturatuce.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
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
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
