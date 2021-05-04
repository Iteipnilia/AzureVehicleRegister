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

        [Authorize(Roles = "User, Admin, Superadmin")]
        [HttpPost]
        [Route("api/vehicleservice")]
        public IHttpActionResult CreateVehicleService(VehicleServiceDto request, int customerId, int vehicleId)
        {
            VehicleServiceFactory vehicleServiceFactory = new VehicleServiceFactory();
            IVehicleService vehicleService = vehicleServiceFactory.CreateService(request.VehicleServiceId,
                                                                                 request.ServiceDate,
                                                                                 request.ServiceType,
                                                                                 request.IsServiceCompleted);

            vehicleServiceRepository_.Create(vehicleService, vehicleId, customerId);

            return Ok();
        }
 
        //=======GET=ALL=====================================================
        
        [Authorize(Roles = "Admin, SuperaAmin")]
        [HttpGet]
        [Route("api/vehicles")]
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
                    BookedService = vehicle.BookedService,
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
        
        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpGet]
        [Route("api/vehicle/{id}")]
        public IHttpActionResult GetVehicleById(int vehicleId)
        {
            var vehicle = vehicleRepository_.GetById(vehicleId);

            var respons = new VehicleDto()
            {
                VehicleId = vehicle.VehicleId,
                RegistrationNumber = vehicle.RegistrationNumber,
                Model = vehicle.Model,
                Brand = vehicle.Brand,
                VehicleType = vehicle.VehicleType,
                Weight = vehicle.Weight,
                BookedService = vehicle.BookedService,
                FirstUseInTraffic = vehicle.FirstUseInTraffic
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
        [Route("api/vehicle/")]
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
        [Route("api/vehicle/{id}")]
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