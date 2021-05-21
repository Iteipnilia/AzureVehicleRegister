using System.Collections.Generic;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Repository.Interfaces
{
    public interface IVehicleServiceRepository
    {
        bool Create(IVehicleService service, int vehicleId);
        IVehicleService GetById(int serviceId);
        IEnumerable<IVehicleService> GetAllVehicleServices(bool finnished);
        IEnumerable<IVehicleService> GetVehiclesServiceHistory(int vehicleID);
        IVehicleService GetVehicleServiceByVehicleId(int vehicleId);
        void Update(IVehicleService service);
        void DeleteService(int serviceId);
    }
}
