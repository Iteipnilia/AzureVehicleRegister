using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace VehicleRegister.API.Controllers
{
    public class UserAPIController : ApiController
    {
        //This method is For all types of role  
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/values/getvalues")]
        public IHttpActionResult GetValues()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == System.Security.Claims.ClaimTypes.Role).Select(c => c.Value);
            var LogTime = identity.Claims
                        .FirstOrDefault(c => c.Type == "LoggedOn").Value;
            return Ok("Hello: " + identity.Name + ", " +
                "Your Role(s) are: " + string.Join(",", roles.ToList()) +
                "Your Login time is :" + LogTime);
        }
    }
}