using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using VehicleRegister.DTO.Request;

namespace VehicleRegister.API.Controllers
{
    public class UserAPIController : ApiController
    {
        //This method is For all types of role
        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpGet]
        [Route("api/values/getvalues")]
        public IHttpActionResult GetValues()
        {
            /*var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            var LogTime = identity.Claims
                        .FirstOrDefault(c => c.Type == "LoggedOn").Value;

            string message = "Hello: " + identity.Name + ", " +
                "Your Role is: " + identity.Label +
                "Your Login time is :" + LogTime;*/

            return Ok();
        }
    }
}