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
    public class VehicleServiceController : Controller
    {
        private readonly WebApiEndpoints _endpoints;

        public VehicleServiceController()
        {
            _endpoints = new WebApiEndpoints();
        }
        // GET: VehicleService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookVehicleService(VehicleModel vehicle)
        {
            VehicleServiceModel vehicleService = new VehicleServiceModel { VehicleId = vehicle.VehicleId };
            return View("BookVehicleService",vehicleService);
        }
        [HttpPost]
        public ActionResult BookVehicleService(VehicleServiceModel service)
        {
            var createTempVehicle = new VehicleDto { VehicleId = service.VehicleId };
            var createVehicleServiceRequest = new VehicleServiceDto
            {
                Vehicle = createTempVehicle,
                ServiceDate = service.ServiceDate,
                ServiceType = service.ServiceType
            };

            string jsonCreateVehicleService = JsonConvert.SerializeObject(createVehicleServiceRequest);
            var httpContent = new StringContent(jsonCreateVehicleService, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.CreateVehicleService), httpContent).Result;

                if (response == null)
                {
                    return View("About");
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            ViewBag.Message($"Service has been booked {service.ServiceDate}");
            return View("Succes");
        }


        //GetService
        //GetAllService
        // GetServiceHistory
        // UpdateService
        // DeleteService
    }
}