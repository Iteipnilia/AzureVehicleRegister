using System;
using System.Collections.Generic;
using VehicleRegister.Domain.Vehicle.Interfaces;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.VehicleService.Classes
{
    public class VehicleServiceFactory
    {
        public IVehicleService CreateService(int serviceId, IVehicle vehicle, DateTime serviceDate, string serviceType, bool? isServiceComplete)
        {
            return new VehicleService(serviceId, vehicle, serviceDate, serviceType, isServiceComplete);

        }

        public IVehicleService CreateServices(int serviceId, List<IVehicle> vehicles, DateTime serviceDate, string serviceType, bool? isServiceCompleted)
        {
            foreach (var vehicle in vehicles)
            {
                return new VehicleService(serviceId, vehicle, serviceDate, serviceType, isServiceCompleted);
            }
            return null;
        }
    }
}

