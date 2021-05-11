using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.Vehicle.Interfaces;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.Vehicle.Classes
{
    public class VehicleFactory
    {
        public IVehicle CreateVehicle(int vehicleId, string registrationNumber, string model, string brand, 
                                        double weight, bool? isRegistered, DateTime firstUseInTraffic)
        {
            switch (weight)
            {
                case double w when (w > 1800 && w < 2500):
                    return new MediumVehicle(vehicleId, registrationNumber, model, brand, weight, isRegistered, firstUseInTraffic);

                case double w when (w >= 2500):
                    return new HeavyVehicle(vehicleId, registrationNumber, model, brand, weight, isRegistered, firstUseInTraffic);

                default:
                    return new LightVehicle(vehicleId, registrationNumber, model, brand, weight, isRegistered, firstUseInTraffic);
            }
        }
    }
}
