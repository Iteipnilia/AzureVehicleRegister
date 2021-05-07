using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleRegister.Domain.Vehicle.Classes;
using VehicleRegister.Domain.Vehicle.Interfaces;
using VehicleRegister.Domain.VehicleService.Classes;
using VehicleRegister.Domain.VehicleService.Interfaces;
using VehicleRegister.DTO.Request;
using VehicleRegister.Repository.Interfaces;

namespace VehicleRegister.API.Controllers
{
    public class VehicleRegAPIController : ApiController
    {
        private readonly IVehicleRepository vehicleRepository_;
        private readonly IVehicleServiceRepository vehicleServiceRepository_;
 

        public VehicleRegAPIController(IVehicleRepository vehicleRepository,
                                       IVehicleServiceRepository vehicleServiceRepository)
        {
            vehicleRepository_ = vehicleRepository;
            vehicleServiceRepository_ = vehicleServiceRepository;
        }

        //========CREATE=================================================================

        //[Authorize(Roles = "User, Admin, Superadmin")]
        [HttpPost]
        [AllowAnonymous]
        [Route("api/createvehicle")]
        public IHttpActionResult CreateVehicle(VehicleDto request)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            IVehicle vehicle = vehicleFactory.CreateVehicle(request.VehicleId,
                                                            request.RegistrationNumber,
                                                            request.Model,
                                                            request.Brand,
                                                            request.Weight,
                                                            request.IsRegistered,
                                                            null,
                                                            request.FirstUseInTraffic);

            vehicleRepository_.Create(vehicle);

            return Ok();
        }

        //[Authorize(Roles = "User, Admin, Superadmin")]
        [HttpPost]
        [AllowAnonymous]
        [Route("api/bookvehicleservice")]
        public IHttpActionResult CreateVehicleService(VehicleServiceDto request)
        {
            VehicleServiceFactory vehicleServiceFactory = new VehicleServiceFactory();
            IVehicleService vehicleService = vehicleServiceFactory.CreateService(request.VehicleServiceId,
                                                                                 request.ServiceDate,
                                                                                 request.ServiceType,
                                                                                 request.IsServiceCompleted);

            vehicleServiceRepository_.Create(vehicleService, request.Vehicle.VehicleId);

            return Ok();
        }
 
        //=======GET=ALL=====================================================
        
        //[Authorize(Roles = "Admin, SuperaAmin")]
        [HttpGet]
        [AllowAnonymous]
        [Route("api/getallvehicles")]
        public IHttpActionResult GetAllVehicles()
        {
            var response = new GetAllVehiclesResponseDto();
            foreach (var vehicle in vehicleRepository_.GetAllVehicles())
            {
                response.Vehicles.Add(new VehicleDto()
                {
                    VehicleId = vehicle.VehicleId,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    Model = vehicle.Model,
                    Brand = vehicle.Brand,
                    VehicleType = vehicle.VehicleType,
                    Weight = vehicle.Weight,
                    YearlyFee = vehicle.YearlyFee,
                    //BookedService = vehicle.BookedService,
                    FirstUseInTraffic = vehicle.FirstUseInTraffic
                });
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet]
        [Route("api/vehicleservices")]
        public IHttpActionResult GetAllVehicleServices()
        {
            var response = new GetAllVehicleServicesResponseDto();
            foreach (var vehicleService in vehicleServiceRepository_.GetAllVehicleServices())
            {
                response.VehicleServices.Add(new VehicleServiceDto()
                {
                    VehicleServiceId = vehicleService.ServiceId,
                    ServiceDate = vehicleService.ServiceDate,
                    ServiceType = vehicleService.ServiceType,
                    IsServiceCompleted = vehicleService.IsServiceCompleted
                });
            }

            return Ok(response);
        }
   
        //=======GET=BY=ID====================================================
        
        //[Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpGet]
        [AllowAnonymous]
        [Route("api/getvehicle")]
        public IHttpActionResult GetVehicleById(VehicleDto vehicle)
        {
            var getvehicle = vehicleRepository_.GetById(vehicle.VehicleId);

            var respons = new VehicleDto()
            {
                VehicleId = getvehicle.VehicleId,
                RegistrationNumber = getvehicle.RegistrationNumber,
                Model = getvehicle.Model,
                Brand = getvehicle.Brand,
                VehicleType = getvehicle.VehicleType,
                Weight = getvehicle.Weight,
                //BookedService = vehicle.BookedService,
                FirstUseInTraffic = getvehicle.FirstUseInTraffic
            };
            return Ok(respons);
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpGet]
        [Route("api/vehicleservice/{id}")]
        public IHttpActionResult GetVehicleServiceById(int vehicleServiceId)
        {
            var vehicleService = vehicleServiceRepository_.GetById(vehicleServiceId);

            var respons = new VehicleServiceDto()
            {
                VehicleServiceId = vehicleService.ServiceId,
                ServiceDate = vehicleService.ServiceDate,
                ServiceType = vehicleService.ServiceType,
                IsServiceCompleted = vehicleService.IsServiceCompleted
            };
            return Ok(respons);
        }

        //=========UPDATE============================================================

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPut]
        [Route("api/updatevehicle")]
        public IHttpActionResult UpdateVehicle(VehicleDto vehicle)
        {
            var update = vehicleRepository_.Update((IVehicle)vehicle);

            return Ok(update);
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPut]
        [Route("api/vehicle")]
        public IHttpActionResult UpdateVehicleService(VehicleServiceDto vehicleService)
        {
            var update = vehicleServiceRepository_.Update((IVehicleService)vehicleService);

            return Ok(update);
        }
  
        //=======DELETE======================================================================
        
        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPut]
        [AllowAnonymous]
        [Route("api/deletevehicle/{id}")]
        public IHttpActionResult DeleteVehicle(int vehicleId)
        {
            vehicleRepository_.DeleteVehicle(vehicleId);

            return Ok();
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPut]
        [Route("api/vehicleservice/{id}")]
        public IHttpActionResult DeleteVehicleService(int vehicleServiceId)
        {
            vehicleServiceRepository_.DeleteService(vehicleServiceId);

            return Ok();
        }

    }
}