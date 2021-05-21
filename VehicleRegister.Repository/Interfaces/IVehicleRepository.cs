
using System.Collections.Generic;
using VehicleRegister.Domain.Vehicle.Interfaces;

namespace VehicleRegister.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        void Create(IVehicle vehicle);
        IVehicle GetVehicleById(int vehicleId);
        IVehicle GetVehicleByReg(string vehicleReg);
        IEnumerable<IVehicle> GetAllVehicles();
        void Update(IVehicle vehicle);
        void DeleteVehicle(int vehicleId);
        void DeleteBookedService(int vehicleId);
    }
}
