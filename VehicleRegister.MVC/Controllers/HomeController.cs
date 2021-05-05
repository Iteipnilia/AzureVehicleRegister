using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
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
    }
}