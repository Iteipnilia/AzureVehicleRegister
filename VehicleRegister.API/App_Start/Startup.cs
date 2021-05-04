
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
            //this is very important line cross orgin source(CORS)it is used to enable cross-site HTTP requests  
            //For security reasons, browsers restrict cross-origin HTTP requests  
            app.UseCors(CorsOptions.AllowAll);
            var provider = new OAuthWebApi();

            OAuthAuthorizationServerOptions OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),//token expiration time  
                Provider = provider
            };

            //app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);//register the request  
        }
    }
}
