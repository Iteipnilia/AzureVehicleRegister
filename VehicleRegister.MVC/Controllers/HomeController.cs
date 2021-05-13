using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(LogInUserModel login)
        {
            var token = GetToken(login.UserName, login.Password);
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Error");
            }

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = httpClient.GetAsync(new Uri(_endpoints.LogInUser)).Result;
                string message = response.Content.ReadAsStringAsync().Result;
                
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message(message);
                    return RedirectToAction("Success", "Vehicle");
                } 
            }

            //Session["token"] = token;
            return View("Index");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetToken(string userName, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var userForm = new Dictionary<string, string>
                        {
                            {"userName", userName },
                            {"password", password },
                            {"grant_type", "password" }
                        };
                var content = new FormUrlEncodedContent(userForm);
                var response = httpClient.PostAsync(_endpoints.GetToken, content).Result;
                var jsonstring = response.Content.ReadAsStringAsync().Result;
                var tokenstring = JsonConvert.DeserializeObject<TokenDto>(jsonstring);

                return tokenstring.AccessToken;
            }
        }
    }
}