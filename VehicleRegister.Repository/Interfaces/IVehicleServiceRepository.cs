using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Repository.Interfaces
{
    public interface IVehicleServiceRepository
    {
        void Create(IVehicleService service, int vehicleId, int customerId);
        IVehicleService GetById(int serviceId);
        IEnumerable<IVehicleService> GetAllVehicleServices();
        IVehicleService Update(IVehicleService service);
        void DeleteService(int serviceId);
    }
}
