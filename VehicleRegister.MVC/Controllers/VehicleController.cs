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

        public ActionResult DetailVehicle(VehicleModel vehicle)
        {
            return View(vehicle);
        }

        //=======CREATE===========================
        public ActionResult CreateVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateVehicle(VehicleModel collection)
        {
            ViewBag.Message = "Vehicle has been created";

            var createVehicleRequest = new VehicleDto
            {
                RegistrationNumber = collection.RegistrationNumber,
                Model = collection.Model,
                Brand = collection.Brand,
                Weight = collection.Weight,
                IsRegistered = collection.IsRegistered,
                FirstUseInTraffic = collection.FirstUseInTraffic
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

        //==============GET=ALL============================
        public ActionResult GetAllVehicles()
        {
            var vehicleList = new List<VehicleModel>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(new Uri(_endpoints.GetVehicles)).Result;
                if (response != null)
                {
                    var jsonGetVehicles = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<GetAllVehiclesResponseDto>(jsonGetVehicles);

                    foreach (var vehicle in responseDto.Vehicles)
                    {
                        var result = new VehicleModel
                        {
                            VehicleId = vehicle.VehicleId,
                            RegistrationNumber = vehicle.RegistrationNumber,
                            Model = vehicle.Model,
                            Brand = vehicle.Brand,
                            Weight = vehicle.Weight,
                            VehicleType = vehicle.VehicleType,
                            YearlyFee = vehicle.YearlyFee,
                            FirstUseInTraffic = vehicle.FirstUseInTraffic,
                            IsRegistered = vehicle.IsRegistered
                        };
                        vehicleList.Add(result);
                    }
                    ViewBag.Message = vehicleList;
                }
            }
            return View(vehicleList);
        }

        //============GET=BY=ID=======================================
        public ActionResult GetVehicleById()
        {
            return View("GetVehicleById");
        }
        [HttpPost]
        public ActionResult GetVehicleById(GetVehicleByIdModel id)
        {
            var vehicleList = new List<VehicleModel>();
            var request = new VehicleDto
            {
                VehicleId = id.VehicleId
            };

            string jsonrequest = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonrequest, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.GetVehicle), httpcontent).Result;
                if (response != null)
                {
                    var jsonGetCustomer = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<VehicleDto>(jsonGetCustomer);

                    var result = new VehicleModel
                    {
                        VehicleId = responseDto.VehicleId,
                        RegistrationNumber = responseDto.RegistrationNumber,
                        Model = responseDto.Model,
                        Brand = responseDto.Brand,
                        VehicleType = responseDto.VehicleType,
                        Weight = responseDto.Weight,
                        IsRegistered = responseDto.IsRegistered,
                        YearlyFee = responseDto.YearlyFee,
                        //BookedService = responseDto.BookedService,
                        FirstUseInTraffic = responseDto.FirstUseInTraffic
                    };
                    vehicleList.Add(result);
                    ViewBag.Message = vehicleList;
                }
            }
            VehicleModel model = vehicleList[0];// NEJ :(
            return View("DetailVehicle", model);
        }

        //==========DELETE=====================================
        public ActionResult DeleteVehicle(VehicleModel vehicle)
        {
            return View(vehicle);
        }

        [HttpPost]
        public ActionResult DeleteVehicle(DeleteVehicleModel id)
        {
            var request = new VehicleDto
            {
                VehicleId = id.VehicleId
            };

            string jsonDeleteVehicle = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonDeleteVehicle, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.DeleteVehicle), httpcontent).Result;
                if (response == null)
                {
                    return View("About");
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            ViewBag.Message = "Vehicle has been deleted";
            return View("Success");
        }

        //==========UPDATE===============================================

        public ActionResult UpdateVehicle(UpdateVehicleModel vehicle)
        {
            return View("UpdateVehicle", vehicle);
        }
        [HttpPost]
        public ActionResult UpdateVehicle(VehicleModel vehicle)
        {
            var vehicleUpdateRequest = new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                RegistrationNumber = vehicle.RegistrationNumber,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                FirstUseInTraffic = vehicle.FirstUseInTraffic,
                IsRegistered = vehicle.IsRegistered
            };
            string jsonCreateCustomer = JsonConvert.SerializeObject(vehicleUpdateRequest);
            var httpContent = new StringContent(jsonCreateCustomer, Encoding.UTF8, "application/json");
           
            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.UpdateVehicle), httpContent).Result;

                if (response == null)
                {
                    return View("About");
                }
                else if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            ViewBag.Message = "Vehicle has been updated";
            return View("Success");
        }
    }
}