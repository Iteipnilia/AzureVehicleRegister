
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Microsoft.Owin.Cors;
using VehicleRegister.API.AuthorizationServerProvider;

[assembly: OwinStartup(typeof(VehicleRegister.API.App_Start.Startup))]

namespace VehicleRegister.API.App_Start
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOauth(app);

            WebApiConfig.Register(config);//register the request  
            app.UseCors(CorsOptions.AllowAll);
        }

        public void ConfigureOauth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                Provider = new OAuthWebApi(),
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60)//token expiration time  
            };

            //token generation
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
