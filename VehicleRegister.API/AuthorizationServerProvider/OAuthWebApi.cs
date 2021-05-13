using System;
using System.Linq;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using VehicleRegister.Repository.DataAccess;

namespace VehicleRegister.API.AuthorizationServerProvider
{
    public class OAuthWebApi : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var db = new AzureDbAccessDataContext())
            {
                if (db != null)
                {
                    var user = db.ApiUsers.Where(o => o.UserName == context.UserName && o.UserPasswd == context.Password).FirstOrDefault();
                    if (user != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRole));
                        identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                        identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                        await Task.Run(() => context.Validated(identity));
                    }
                    else
                    {
                        context.SetError("Wrong Credentials", "Provided username and password is incorrect");
                    }
                }
                else
                {
                    context.SetError("Wrong Credentials", "Provided username and password is incorrect");
                }
                return;
            }
        }
    }
}