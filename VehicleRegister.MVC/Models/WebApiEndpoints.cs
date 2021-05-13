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
        public string GetVehicles => "https://localhost:44374/api/getallvehicles";
        public string GetVehicle => "https://localhost:44374/api/getvehicle";
        public string UpdateVehicle => "https://localhost:44374/api/updatevehicle";
        public string DeleteVehicle => "https://localhost:44374/api/deletevehicle";

        public string CreateVehicleService => "https://localhost:44374/api/bookvehicleservice";
        public string GetActiveVehicleServices => "https://localhost:44374/api/bookedvehicleservices";
        public string GetFinnishedVehicleServices => "https://localhost:44374/api/finnishedvehicleservices";
        public string GetVehiclesServiceHistory => "https://localhost:44374/api/vehicleservicehistory";
        public string GetVehicleService => HostName + "api/vehicleservice";
        public string UpdateVehicleService => HostName + "api/vehicleservice";
        public string DeleteVehicleService => HostName + "api/vehicleservice";
        public string GetToken => "https://localhost:44374/token";
        public string LogInUser => "https://localhost:44374/api/values/getvalues";

    }
}
