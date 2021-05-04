using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.Vehicle.Interfaces;

namespace VehicleRegister.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        void Create(IVehicle vehicle);
        IVehicle GetById(int vehicleId);
        IEnumerable<IVehicle> GetAllVehicles();
        IVehicle Update(IVehicle vehicle);
        void DeleteVehicle(int vehicleId);
    }
}
