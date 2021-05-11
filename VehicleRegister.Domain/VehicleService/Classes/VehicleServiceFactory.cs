using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.Vehicle.Interfaces;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.VehicleService.Classes
{
    public class VehicleServiceFactory
    {
        public IVehicleService CreateService(int serviceId, IVehicle vehicle, DateTime serviceDate, string serviceType, bool isServiceComplete)
        {
            return new VehicleService(serviceId, vehicle, serviceDate, serviceType, isServiceComplete);

        }
    }
}
