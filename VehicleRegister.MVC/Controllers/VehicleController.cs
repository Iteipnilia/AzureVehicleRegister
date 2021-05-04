using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VehicleRegister.DTO.Request;
using VehicleRegister.MVC.Models;

namespace VehicleRegister.MVC.Controllers
{
    public class VehicleController : Controller
    {
        private readonly WebApiEndpoints _endpoints;

        public VehicleController()
        {
            _endpoints = new WebApiEndpoints();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateVehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVehicle(VehicleModel model)
        {
            ViewBag.Message = "Vehicle has been created";

            var createVehicleRequest = new VehicleDto
            {
                RegistrationNumber = model.RegistrationNumber,
                Model = model.Model,
                Brand = model.Brand,
                Weight = model.Weight,
                IsRegistered = model.IsRegistered,
                FirstUseInTraffic = model.FirstUseInTraffic
            };

            string jsonCreateVehicle = JsonConvert.SerializeObject(createVehicleRequest);
            var httpContent = new StringContent(jsonCreateVehicle, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.CreateVehicle), httpContent).Result;

                if (response == null)
                {
                    return View("About");
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            return View("Success");
        }
    }
}