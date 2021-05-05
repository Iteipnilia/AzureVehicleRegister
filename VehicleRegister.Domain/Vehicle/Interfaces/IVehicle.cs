using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.Vehicle.Interfaces
{
    public interface IVehicle
    {
        int VehicleId { get; }
        string RegistrationNumber { get; }
        string Model { get; }
        string Brand { get; }
        string VehicleType { get; }
        double Weight { get; }
        bool? IsRegistered { get; }
        double YearlyFee { get; }
        IVehicleService BookedService { get; }
        DateTime FirstUseInTraffic { get; }
        List<IVehicleService> ServiceHistory { get; }

        void RegisterVehicle();

        void UnregisterVehicle();

        bool CheckIfServiceIsCompleted(IVehicleService service);

        void AddNewBookedService(IVehicleService service);

        void AddCompletedServiceToServiceHistory(IVehicleService service);
    }
}
