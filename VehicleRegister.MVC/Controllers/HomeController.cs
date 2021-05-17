using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VehicleRegister.DTO.Request;
using VehicleRegister.MVC.Models;

namespace VehicleRegister.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly WebApiEndpoints _endpoints;

        public HomeController()
        {
            _endpoints = new WebApiEndpoints();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(LogInUserModel login)
        {
            if(login.UserName==null || login.Password==null)
            {
                throw new NullReferenceException();
            }
            
            var token = GetToken(login.UserName, login.Password);
            if (string.IsNullOrEmpty(token))
            {
                return View("Error");
            }

            Session["tokenkey"] = token;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["tokenkey"].ToString());
                
                var response = httpClient.GetAsync(new Uri(_endpoints.LogInUser)).Result;
                var message = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return View("Index");
                } 
            }
            return View("Error");
        }


        public string GetToken(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var userForm = new Dictionary<string, string>
                        {
                            {"UserName", username },
                            {"Password", password },
                            {"grant_type", "password" }
                        };
                var content = new FormUrlEncodedContent(userForm);
                var response = httpClient.PostAsync(_endpoints.GetToken, content).Result;
                var token = response.Content.ReadAsAsync<TokenDto>(new[] { new JsonMediaTypeFormatter() }).Result;
                /*var jsonstring = response.Content.ReadAsStringAsync().Result;
                var tokenstring = JsonConvert.DeserializeObject<TokenDto>(jsonstring);*/

                return token.AccessToken;
            }
        }
    }
}