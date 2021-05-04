using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegister.Domain.VehicleService.Interfaces
{
    public interface IVehicleService
    {
        int ServiceId { get; }
        DateTime ServiceDate { get; }
        string ServiceType { get; }
        bool IsServiceCompleted { get; }

        void SetServiceCompleted();

        void ChangeServiceDate(DateTime dateTime);
    }
}
