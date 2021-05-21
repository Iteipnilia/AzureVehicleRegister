using System;
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

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
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
                                                            request.FirstUseInTraffic);

            vehicleRepository_.Create(vehicle);

            return Ok();
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/bookvehicleservice")]
        public IHttpActionResult CreateVehicleService(VehicleServiceDto request)
        {
            VehicleServiceFactory vehicleServiceFactory = new VehicleServiceFactory();
            IVehicleService vehicleService = vehicleServiceFactory.CreateService(request.VehicleServiceId,
                                                                                 null,
                                                                                 request.ServiceDate,
                                                                                 request.ServiceType,
                                                                                 request.IsServiceCompleted);

            if (vehicleServiceRepository_.Create(vehicleService, request.VehicleId))
                return Ok();
            else
                return NotFound();
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/bookvehicleservice2")]
        public IHttpActionResult CreateVehicleServiceForManyVehicles(VehicleServiceDto request)
        {
            VehicleServiceFactory vehicleServiceFactory = new VehicleServiceFactory();
            IVehicleService vehicleService = vehicleServiceFactory.CreateService(request.VehicleServiceId,
                                                                                 (IVehicle)request.Vehicle,
                                                                                 request.ServiceDate,
                                                                                 request.ServiceType,
                                                                                 request.IsServiceCompleted);
            foreach(int id in request.VehicleIdList )
            {
                vehicleServiceRepository_.Create(vehicleService, id);
            }

            return Ok();
        }

        //=======GET=ALL=====================================================

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet]
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
                    IsRegistered = vehicle.IsRegistered,
                    FirstUseInTraffic = vehicle.FirstUseInTraffic
                });
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet]
        [Route("api/bookedvehicleservices")]
        public IHttpActionResult GetAllActiveVehicleServices()
        {
            var response = new GetAllVehicleServicesResponseDto();
            foreach (var vehicleService in vehicleServiceRepository_.GetAllVehicleServices(false))
            {
                response.VehicleServices.Add(new VehicleServiceDto()
                {
                    VehicleServiceId = vehicleService.ServiceId,
                    VehicleId = vehicleService.Vehicle.VehicleId,
                    ServiceDate = vehicleService.ServiceDate,
                    ServiceType = vehicleService.ServiceType,
                    IsServiceCompleted = vehicleService.IsServiceCompleted
                });
            }

            return Ok(response);
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpGet]
        [Route("api/finnishedvehicleservices")]
        public IHttpActionResult GetAllFinnishedVehicleServices()
        {
            var response = new GetAllVehicleServicesResponseDto();
            foreach (var vehicleService in vehicleServiceRepository_.GetAllVehicleServices(true))
            {
                response.VehicleServices.Add(new VehicleServiceDto()
                {
                    VehicleServiceId = vehicleService.ServiceId,
                    VehicleId = vehicleService.Vehicle.VehicleId,
                    ServiceDate = vehicleService.ServiceDate,
                    ServiceType = vehicleService.ServiceType,
                    IsServiceCompleted = vehicleService.IsServiceCompleted
                });
            }

            return Ok(response);
        }

        //=======GET=BY=ID====================================================

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/getvehicle")]
        public IHttpActionResult GetVehicleById(VehicleDto vehicle)
        {
            var getvehicle = vehicleRepository_.GetVehicleById(vehicle.VehicleId);
            var getService = vehicleServiceRepository_.GetVehicleServiceByVehicleId(vehicle.VehicleId);

            var getdate = new VehicleServiceDto();

            if (getService != null) { getdate.ServiceDate = getService.ServiceDate; }

            if(getvehicle !=null)
            {
                var response = new VehicleDto()
                {
                    VehicleId = getvehicle.VehicleId,
                    RegistrationNumber = getvehicle.RegistrationNumber,
                    Model = getvehicle.Model,
                    Brand = getvehicle.Brand,
                    YearlyFee = getvehicle.YearlyFee,
                    VehicleType = getvehicle.VehicleType,
                    IsRegistered = getvehicle.IsRegistered,
                    Weight = getvehicle.Weight,
                    FirstUseInTraffic = getvehicle.FirstUseInTraffic,
                    BookedService = getdate.ServiceDate
                };
                return Ok(response);
            }
            else
            return NotFound();
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/vehicleservice")]
        public IHttpActionResult GetVehicleServiceById(VehicleServiceDto vehicleService)
        {
            var vehicleServiceRequest = vehicleServiceRepository_.GetById(vehicleService.VehicleServiceId);

            var respons = new VehicleServiceDto()
            {
                VehicleServiceId = vehicleServiceRequest.ServiceId,
                ServiceDate = vehicleServiceRequest.ServiceDate,
                ServiceType = vehicleServiceRequest.ServiceType,
                IsServiceCompleted = vehicleServiceRequest.IsServiceCompleted
            };
            return Ok(respons);
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/vehicleservicebyvehicleid")]
        public IHttpActionResult GetVehicleServiceByVehicleId(VehicleDto vehicle)
        {
            var vehicleService = vehicleServiceRepository_.GetVehicleServiceByVehicleId(vehicle.VehicleId);

            if (vehicleService != null)
            {
                var respons = new VehicleServiceDto()
                {
                    VehicleServiceId = vehicleService.ServiceId,
                    ServiceDate = vehicleService.ServiceDate,
                    ServiceType = vehicleService.ServiceType,
                };
                return Ok(respons);
            }
            else
                return NotFound();
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/vehicleservicehistory")]
        public IHttpActionResult GetOneVehicleServiceHistory(VehicleDto vehicle)
        {
            var response = new GetAllVehicleServicesResponseDto();
            foreach (var vehicleService in vehicleServiceRepository_.GetVehiclesServiceHistory(vehicle.VehicleId))
            {
                response.VehicleServices.Add(new VehicleServiceDto()
                {
                    VehicleId = vehicleService.Vehicle.VehicleId,
                    VehicleServiceId = vehicleService.ServiceId,
                    ServiceDate = vehicleService.ServiceDate,
                    ServiceType = vehicleService.ServiceType,
                    IsServiceCompleted = vehicleService.IsServiceCompleted
                });
            }

            return Ok(response);
        }

        //=========UPDATE============================================================

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/updatevehicle")]
        public IHttpActionResult UpdateVehicle(VehicleDto vehicle)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();
            IVehicle vehicleUpdate = vehicleFactory.CreateVehicle(vehicle.VehicleId,
                                                            vehicle.RegistrationNumber,
                                                            vehicle.Model,
                                                            vehicle.Brand,
                                                            vehicle.Weight,
                                                            vehicle.IsRegistered,
                                                            vehicle.FirstUseInTraffic);
            vehicleRepository_.Update(vehicleUpdate);

            return Ok();
        }

        [Authorize(Roles = "User, Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/updatevehicleservice")]
        public IHttpActionResult UpdateVehicleService(VehicleServiceDto update)
        {
            VehicleServiceFactory vehicleServiceFactory = new VehicleServiceFactory();
            IVehicleService vehicleService = vehicleServiceFactory.CreateService(update.VehicleServiceId,
                                                                                 null,
                                                                                 update.ServiceDate,
                                                                                 update.ServiceType,
                                                                                 update.IsServiceCompleted);
            vehicleServiceRepository_.Update(vehicleService);

            return Ok();
        }
  
        //=======DELETE======================================================================
        
        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/deletevehicle")]
        public IHttpActionResult DeleteVehicle(VehicleDto vehicle)
        {
            int id = vehicle.VehicleId;
            vehicleRepository_.DeleteVehicle(id);

            return Ok();
        }

        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        [Route("api/deletevehicleservice")]
        public IHttpActionResult DeleteVehicleService(VehicleServiceDto serviceModel)
        {
            int serviceid = serviceModel.VehicleServiceId;
            int vehicleid = serviceModel.VehicleId;
            vehicleRepository_.DeleteBookedService(vehicleid);
            vehicleServiceRepository_.DeleteService(serviceid);

            return Ok();
        }

    }
}