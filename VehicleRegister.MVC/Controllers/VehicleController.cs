using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        //=======CREATE=VEHICLE==========================
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
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["tokenkey"].ToString());
                var response = client.PostAsync(new Uri(_endpoints.CreateVehicle), httpContent).Result;

                 if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            return View("Success");
        }

        //==============GET=ALL=VEHICLES===========================
        public ActionResult GetAllVehicles()
        {
            var vehicleList = new List<VehicleModel>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["tokenkey"].ToString());

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

        //============GET=VEHICLE=BY=ID=======================================
        public ActionResult GetVehicleById()
        {
            return View("GetVehicleById");
        }
        [HttpPost]
        public ActionResult GetVehicleById(VehicleModel vehiclebyid)
        {
            var vehicleList = new List<VehicleModel>();
            var request = new VehicleDto{ VehicleId = vehiclebyid.VehicleId };

            string jsonrequest = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonrequest, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.GetVehicle), httpcontent).Result;

                if (response != null)
                {
                    var jsonGetVehicle = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<VehicleDto>(jsonGetVehicle);

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
                        FirstUseInTraffic = responseDto.FirstUseInTraffic
                    };
                    vehicleList.Add(result);
                    ViewBag.Message = vehicleList;
                }
            }
            return View("DetailVehicle", vehicleList.First());
        }

        //==========DELETE=VEHICLE====================================
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

        //==========UPDATE=VEHICLE==============================================

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

        //=================================================================//
        //=================================================================//
        //==================  VEHICLESERVICE CONTROLLERS  =================//
        //=================================================================//
        //=================================================================//


        //============BOOK=VEHICLESERVICE===============================
        public ActionResult BookVehicleService(VehicleModel getvehicleid)
        {
            VehicleServiceModel vehicleService = new VehicleServiceModel { VehicleId = getvehicleid.VehicleId };
            return View("BookVehicleService", vehicleService);
        }
        [HttpPost]
        public ActionResult BookVehicleService(VehicleServiceModel service)
        {
            //var createTempVehicle = new VehicleDto { VehicleId = service.VehicleId };
            var createVehicleServiceRequest = new VehicleServiceDto
            {
                VehicleId = service.VehicleId,
                ServiceDate = service.ServiceDate,
                ServiceType = service.ServiceType,
                IsServiceCompleted= false
            };

            string jsonCreateVehicleService = JsonConvert.SerializeObject(createVehicleServiceRequest);
            var httpContent = new StringContent(jsonCreateVehicleService, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.CreateVehicleService), httpContent).Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            
            ViewBag.Message("Service has been booked");
            return View("Success");
        }
        
        //========GET=ALL=VEHICLESERVICES==================================

        // GET ALL ACTIVE SERVICES
        [HttpGet]
        public ActionResult GetAllBookedServices()
        {
            var vehicleServiceList = new List<GetVehicleServicesModel>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(new Uri(_endpoints.GetActiveVehicleServices)).Result;
                if (response != null)
                {
                    var jsonGetVehicleServices = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<GetAllVehicleServicesResponseDto>(jsonGetVehicleServices);

                    foreach (var service in responseDto.VehicleServices)
                    {
                        var vehicleServices = new GetVehicleServicesModel
                        {
                            VehicleServiceId = service.VehicleServiceId,
                            VehicleId = service.VehicleId,
                            ServiceDate = service.ServiceDate,
                            ServiceType = service.ServiceType
                        };
                        vehicleServiceList.Add(vehicleServices);
                    }
                    ViewBag.Message = vehicleServiceList;
                }
            }
            return View("GetAllVehicleServices", vehicleServiceList);
        }

        // GET ALL FINNISHED SERVICES
        public ActionResult GetAllServiceHistories()
        {
            var vehicleServiceList = new List<GetVehicleServicesModel>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(new Uri(_endpoints.GetFinnishedVehicleServices)).Result;
                if (response != null)
                {
                    var jsonGetVehicleServices = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<GetAllVehicleServicesResponseDto>(jsonGetVehicleServices);

                    foreach (var service in responseDto.VehicleServices)
                    {
                        var result = new GetVehicleServicesModel
                        {
                            VehicleServiceId = service.VehicleServiceId,
                            VehicleId = service.Vehicle.VehicleId,
                            ServiceDate = service.ServiceDate,
                            ServiceType = service.ServiceType
                        };
                        vehicleServiceList.Add(result);
                    }
                    ViewBag.Message = vehicleServiceList;
                }
                else { return View("Error"); }
            }
            return View("ServiceHistory ", vehicleServiceList);
        }

        // GET SERVICEHISTORY FOR ONE VEHICLE
        public ActionResult GetOneVehiclesServiceHistory(VehicleModel vehicle)
        {
            var request = new VehicleDto
            {
                VehicleId = vehicle.VehicleId
            };

            string jsonrequest = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonrequest, Encoding.UTF8, "application/json");

            var vehicleServiceList = new List<GetVehicleServicesModel>();
            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.GetVehiclesServiceHistory), httpcontent).Result;
                if (response != null)
                {
                    var jsonGetVehicleServices = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<GetAllVehicleServicesResponseDto>(jsonGetVehicleServices);

                    foreach (var service in responseDto.VehicleServices)
                    {
                        var result = new GetVehicleServicesModel
                        { 
                            VehicleServiceId = service.VehicleServiceId,
                            VehicleId = service.Vehicle.VehicleId,
                            ServiceDate = service.ServiceDate,
                            ServiceType = service.ServiceType
                        };
                        vehicleServiceList.Add(result);
                    }
                    ViewBag.Message = vehicleServiceList;
                }
                else { return View("Error"); }
            }
            return View("ServiceHistory", vehicleServiceList);
        }

        //=============GET=VEHICLESERVICE=BY=ID===============================================
        [HttpGet]
        public ActionResult GetVehicleServiceById(GetVehicleServicesModel serviceId)
        {
            var vehicleServiceList = new List<GetVehicleServicesModel>();
            var request = new VehicleServiceDto { VehicleServiceId = serviceId.VehicleServiceId };

            string jsonrequest = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonrequest, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.GetVehicleService), httpcontent).Result;

                if (response != null)
                {
                    var jsonGetVehicleService = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<VehicleServiceDto>(jsonGetVehicleService);

                    var result = new GetVehicleServicesModel
                    {
                        VehicleServiceId = responseDto.VehicleServiceId,
                        ServiceDate = responseDto.ServiceDate,
                        ServiceType = responseDto.ServiceType
                    };
                    vehicleServiceList.Add(result);
                    ViewBag.Message = vehicleServiceList;
                }
            }
            return View("DetailVehicleService", vehicleServiceList.First());
        }

        //============GET=VEHICLESERVICE=BY=VEHICLEID========================================
        [HttpGet]
        public ActionResult GetVehicleServiceByVehicleId(VehicleModel vehicle)
        {
            var vehicleServiceList = new List<GetVehicleServicesModel>();
            var request = new VehicleDto { VehicleId = vehicle.VehicleId };

            string jsonrequest = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonrequest, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.GetVehicleServiceByVehicleId), httpcontent).Result;

                if (response != null)
                {
                    var jsonGetVehicleService = response.Content.ReadAsStringAsync().Result;
                    var responseDto = JsonConvert.DeserializeObject<VehicleServiceDto>(jsonGetVehicleService);

                    var result = new GetVehicleServicesModel
                    {
                        VehicleServiceId = responseDto.VehicleServiceId,
                        ServiceDate = responseDto.ServiceDate,
                        ServiceType = responseDto.ServiceType
                    };
                    vehicleServiceList.Add(result);
                    ViewBag.Message = vehicleServiceList;
                }
            }
            return View("DetailVehicleService", vehicleServiceList.First());
        }

        //==========UPDATE=VEHICLESERVICE=================================

        public ActionResult UpdateVehicleService(VehicleServiceModel vehicleService)
        {
            return View("UpdateVehicleService", vehicleService);
        }
        [HttpPost]
        public ActionResult UpdateVehicleService(UpdateVehicleServiceModel updateService)
        {
            var vehicleServiceUpdateRequest = new VehicleServiceDto
            {
                VehicleServiceId = updateService.VehicleServiceId,
                ServiceDate = updateService.ServiceDate,
                ServiceType = updateService.ServiceType,
                IsServiceCompleted = updateService.IsServiceCompleted
            };
            string jsonCreateCustomer = JsonConvert.SerializeObject(vehicleServiceUpdateRequest);
            var httpContent = new StringContent(jsonCreateCustomer, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.UpdateVehicleService), httpContent).Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            ViewBag.Message = "Vehicleservice has been updated";
            return View("Success");
        }

        //=======DELETE=VEHICLESERVICE===========================================
        public ActionResult DeleteVehicleService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteVehicleService(DeleteVehicleServiceModel vehicleService)
        {
            var request = new VehicleServiceDto
            {
                VehicleId= vehicleService.VehicleId,
                VehicleServiceId = vehicleService.VehicleServiceId
            };

            string jsonDeleteVehicle = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(jsonDeleteVehicle, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(_endpoints.DeleteVehicleService), httpcontent).Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            ViewBag.Message = "Vehicleservice has been deleted";
            return View("Success");
        }
        
        // LÄGGA TILL EN TABLE SOM HETER SERVICE HISTORY????????

        // TRIGGER SOM AUTOMATISKT ÖVERFÖR INFO OM IsServiceComplete==true: TESTA
        
        // RADERAR FRÅN VEHICLE OCH VEHICLESERVICE
        
        // SKAPA EN SIMPEL LOGGER OCH LÄGG TILL TRY CATCH

        // FIXA GETALL SERVICE HISTORIES

        // SHOW BOOKED SERVICE ON VEHICLE DETAIL
    }
}