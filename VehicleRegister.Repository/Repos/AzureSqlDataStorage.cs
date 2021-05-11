using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.Vehicle.Classes;
using VehicleRegister.Domain.Vehicle.Interfaces;
using VehicleRegister.Domain.VehicleService.Classes;
using VehicleRegister.Domain.VehicleService.Interfaces;
using VehicleRegister.Repository.DataAccess;
using VehicleRegister.Repository.Interfaces;

namespace VehicleRegister.Repository.Repos
{
    public class AzureSqlDataStorage : IVehicleRepository, IVehicleServiceRepository
    {
        private readonly AzureDbAccessDataContext datacontext;

        //private readonly ILogger _logger;

        public AzureSqlDataStorage()
        {
            datacontext = new AzureDbAccessDataContext();
            //_logger = new AzureDatabaseLogger();

        }

        //==============\\
        //===>CREATE<===\\
        //==============\\

        //=====VEHICLE=======================================================================================
        public void Create(IVehicle vehicle)
        {
            var newVehicle = new Vehicle
            {
                VehicleId = vehicle.VehicleId,
                RegestrationNumber = vehicle.RegistrationNumber,
                Model = vehicle.Model,
                Brand = vehicle.Brand,
                Vehicle_Type = vehicle.VehicleType,
                Weight_ = (Decimal)vehicle.Weight,
                IsRegistered = vehicle.IsRegistered,
                YearlyFee = (Decimal)vehicle.YearlyFee,
                FirstUseInTraffic = vehicle.FirstUseInTraffic
            };
            datacontext.Vehicles.InsertOnSubmit(newVehicle);
            datacontext.SubmitChanges();
        }

        //=====VEHICLESERVICE=================================================================================
        public void Create(IVehicleService service, int vehicleId)
        {
            var newVehicleService = new VehicleService
            {
                VehicleServiceId = service.ServiceId,
                VehicleId = vehicleId,
                ServiceDate = service.ServiceDate,
                VehicleService_Type = service.ServiceType,
                IsServiceCompleted = service.IsServiceCompleted
            };

            datacontext.VehicleServices.InsertOnSubmit(newVehicleService);
            datacontext.SubmitChanges();
        }// Måste se till att det inte går att boka tid om en tid redan finns
        //===================================================================================================

        //==============\\
        //===>DELETE<===\\
        //==============\\

        //=====VEHICLE=======================================================================================
        //Radera tillhörande services??
        public void DeleteVehicle(int vehicleId)
        {
            var deleteVehicle = datacontext.Vehicles.Where(x => x.VehicleId == vehicleId).SingleOrDefault();

            datacontext.Vehicles.DeleteOnSubmit(deleteVehicle);
            datacontext.SubmitChanges();
        }
        //=====VEHICLESERVICE=================================================================================

        public void DeleteService(int serviceId)
        {
            var deleteService = datacontext.VehicleServices.Where(x => x.VehicleServiceId == serviceId).SingleOrDefault();

            datacontext.VehicleServices.DeleteOnSubmit(deleteService);
            datacontext.SubmitChanges();
        }
        //======================================================================================================

        //===============\\
        //===>GET ALL<===\\
        //===============\\

        //=====VEHICLE=======================================================================================
        public IEnumerable<IVehicle> GetAllVehicles()
        {
            var vehicleList = new List<IVehicle>();
            var vehicleFactory = new VehicleFactory();
            foreach (var entity in datacontext.Vehicles.ToList())
            {
                IVehicle vehicle = vehicleFactory.CreateVehicle(entity.VehicleId,
                                                                entity.RegestrationNumber,
                                                                entity.Model,
                                                                entity.Brand,
                                                                (Double)entity.Weight_,
                                                                entity.IsRegistered,
                                                                (DateTime)entity.FirstUseInTraffic);

                vehicleList.Add(vehicle);
            }
            return vehicleList;
        }

        //=====VEHICLESERVICE=================================================================================
        public IEnumerable<IVehicleService> GetAllVehicleServices(bool finnishedServices)
        {
            var vehicleServiceList = new List<IVehicleService>();
            var vehicleServiceFactory = new VehicleServiceFactory();
            foreach (var entity in datacontext.VehicleServices.ToList())
            {
                if(entity.IsServiceCompleted ==finnishedServices)
                {
                    IVehicleService service = vehicleServiceFactory.CreateService(entity.VehicleServiceId,
                                                                                  GetVehicleById((int)entity.VehicleId),
                                                                                 (DateTime)entity.ServiceDate,
                                                                                  entity.VehicleService_Type,
                                                                                 (bool)entity.IsServiceCompleted);
                    vehicleServiceList.Add(service);
                }
            }
            return vehicleServiceList;
        }
        //====================================================================================================

        public IEnumerable<IVehicleService> GetVehiclesServiceHistory(int vehicleId)
        {
            var vehicleServiceList = new List<IVehicleService>();
            var vehicleServiceFactory = new VehicleServiceFactory();
            foreach (var entity in datacontext.VehicleServices.Where(c => c.VehicleId == vehicleId).ToList())
            {
                if(entity.IsServiceCompleted ==true)
                {
                    IVehicleService service = vehicleServiceFactory.CreateService(entity.VehicleServiceId,
                                                                    GetVehicleById((int)entity.VehicleId),
                                                                    (DateTime)entity.ServiceDate,
                                                                    entity.VehicleService_Type,
                                                                    (bool)entity.IsServiceCompleted);

                    vehicleServiceList.Add(service);
                }
            }
            return vehicleServiceList;
        }
        //======================================================================================================

        //=================\\
        //===>GET BY ID<===\\
        //=================\\

        //=====VEHICLE=======================================================================================
        public IVehicle GetVehicleById(int vehicleId)
        {
            var getVehicle = datacontext.Vehicles.Where(v => v.VehicleId == vehicleId).FirstOrDefault();
            var vehicleFactory = new VehicleFactory();


            IVehicle vehicle = vehicleFactory.CreateVehicle(vehicleId,
                                                            getVehicle.RegestrationNumber,
                                                            getVehicle.Model,
                                                            getVehicle.Brand,
                                                            (double)getVehicle.Weight_,
                                                            (bool)getVehicle.IsRegistered,
                                                            (DateTime)getVehicle.FirstUseInTraffic);

            return vehicle;

        }

        //=====VEHICLESERVICE=================================================================================
        IVehicleService IVehicleServiceRepository.GetById(int serviceId)
        {
            var getVehicleService = datacontext.VehicleServices.Where(s => s.VehicleServiceId == serviceId).FirstOrDefault();
            var vehicleServiceFactory = new VehicleServiceFactory();

            IVehicleService vehicleService = vehicleServiceFactory.CreateService(getVehicleService.VehicleServiceId,
                                                                                GetVehicleById((int)getVehicleService.VehicleId),
                                                                                 (DateTime)getVehicleService.ServiceDate,
                                                                                 getVehicleService.VehicleService_Type,
                                                                                 (bool)getVehicleService.IsServiceCompleted);
            return vehicleService;
        }

        //=====VEHICLESERVICE=================================================================================
        // SKA DEN VARA I INTERFACE?????
        IVehicleService GetVehicleServiceByVehicleId(int vehicleId)
        {
            var getVehicleService = datacontext.VehicleServices.Where(s => s.VehicleServiceId == vehicleId).FirstOrDefault();
            var vehicleServiceFactory = new VehicleServiceFactory();

            IVehicleService vehicleService = vehicleServiceFactory.CreateService(getVehicleService.VehicleServiceId,
                                                                                 GetVehicleById((int)getVehicleService.VehicleId),
                                                                                 (DateTime)getVehicleService.ServiceDate,
                                                                                 getVehicleService.VehicleService_Type,
                                                                                 (bool)getVehicleService.IsServiceCompleted);
            return vehicleService;
        }



        //==============\\
        //===>UPDATE<===\\
        //==============\\

        //=====VEHICLE=======================================================================================
        public IVehicle Update(IVehicle vehicle)// MÅSTE DEN RETURNERA???
        {
            var vehicleUpdate = datacontext.Vehicles.Where(v => v.VehicleId == vehicle.VehicleId).Single();

            vehicleUpdate.RegestrationNumber = vehicle.RegistrationNumber;
            vehicleUpdate.Model = vehicle.Model;
            vehicleUpdate.Brand = vehicle.Brand;
            vehicleUpdate.Weight_ = (Decimal)vehicle.Weight;
            vehicleUpdate.IsRegistered = vehicle.IsRegistered;

            datacontext.SubmitChanges();

            return (IVehicle)vehicleUpdate;
        }

        //=====VEHICLESERVICE=================================================================================
        public IVehicleService Update(IVehicleService service)
        {
            var serviceUpdate = datacontext.VehicleServices.Where(s => s.VehicleServiceId == service.ServiceId).Single();

            serviceUpdate.ServiceDate = service.ServiceDate;
            serviceUpdate.VehicleService_Type = service.ServiceType;
            serviceUpdate.IsServiceCompleted = service.IsServiceCompleted;

            datacontext.SubmitChanges();

            return (IVehicleService)serviceUpdate;
        }
    }
}
