using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.MVC.Models.Interfaces;

namespace VehicleRegister.MVC.Models
{
    public class WebApiEndpoints : IWebApiEndpoints
    {
        private string HostName => ConfigurationManager.AppSettings["https://localhost:44374/"];//???

        public string CreateVehicle => "https://localhost:44374/api/createvehicle";
        public string GetVehicles => HostName + "api/vehicles";
        public string GetVehicle => HostName + "api/vehicle";
        public string UpdateVehicle => HostName + "api/vehicle";
        public string DeleteVehicle => HostName + "api/vehicle";

        public string CreateVehicleService => HostName + "api/vehicleservice";
        public string GetVehicleServices => HostName + "api/vehicleservices";
        public string GetVehicleService => HostName + "api/vehicleservice";
        public string UpdateVehicleService => HostName + "api/vehicleservice";
        public string DeleteVehicleService => HostName + "api/vehicleservice";

    }
}
