using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.Vehicle.Classes
{
    class MediumVehicle : Vehicle
    {
        private double mediumVehicleYearlyFee = 1800;

        public MediumVehicle(int vehicleId, string registrationNumber, string model, string brand, double weight, bool? isRegistered,
                             IVehicleService bookedService, DateTime firstUseInTraffic) : base(vehicleId, registrationNumber, model,
                             brand, weight, isRegistered, bookedService, firstUseInTraffic)
        {
            vehicleType = "Mediumsized vehicle";
            yearlyFee = mediumVehicleYearlyFee;
        }
    }
}
