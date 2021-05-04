using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegister.MVC.Models.Interfaces
{
    public interface IWebApiEndpoints
    {
        string CreateVehicle { get; }
        string GetVehicles { get; }
        string GetVehicle { get; }
        string UpdateVehicle { get; }
        string DeleteVehicle { get; }

        string CreateVehicleService { get; }
        string GetVehicleServices { get; }
        string GetVehicleService { get; }
        string UpdateVehicleService { get; }
        string DeleteVehicleService { get; }
    }
}
