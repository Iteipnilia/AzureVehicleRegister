using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.Vehicle.Interfaces;

namespace VehicleRegister.Domain.VehicleService.Interfaces
{
    public interface IVehicleService
    {
        int ServiceId { get; }
        IVehicle Vehicle { get; }
        DateTime ServiceDate { get; }
        string ServiceType { get; }
        bool IsServiceCompleted { get; }

        void SetServiceCompleted();

        void ChangeServiceDate(DateTime dateTime);
    }
}
