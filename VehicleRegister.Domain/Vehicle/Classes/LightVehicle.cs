using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.Vehicle.Classes
{
    class LightVehicle : Vehicle
    {
        private double lightVehicleYearlyFee = 1200;

        public LightVehicle(int vehicleId, string registrationNumber, string model, string brand, double weight, bool? isRegistered,
                            DateTime firstUseInTraffic) : base(vehicleId, registrationNumber, model, brand, weight, isRegistered, firstUseInTraffic)
        {
            vehicleType = "Light vehicle";
            yearlyFee = lightVehicleYearlyFee;
        }
    }
}
