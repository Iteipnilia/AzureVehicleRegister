
using System.Configuration;
using VehicleRegister.MVC.Models.Interfaces;

namespace VehicleRegister.MVC.Models
{
    public class WebApiEndpoints : IWebApiEndpoints
    {
        private string HostName => "https://vehicleregisterweb.azurewebsites.net/";//ConfigurationManager.AppSettings["HostName"];

        public string CreateVehicle => HostName + "api/createvehicle";
        public string GetVehicles => HostName + "api/getallvehicles";
        public string GetVehicle => HostName + "api/getvehicle";
        public string UpdateVehicle => HostName + "api/updatevehicle";
        public string DeleteVehicle => HostName + "api/deletevehicle";

        public string CreateVehicleService => HostName + "api/bookvehicleservice";
        
        public string GetActiveVehicleServices => HostName + "api/bookedvehicleservices";
        public string GetFinnishedVehicleServices => HostName + "api/finnishedvehicleservices";
        public string GetVehiclesServiceHistory => HostName + "api/vehicleservicehistory";
        public string GetVehicleService => HostName + "api/vehicleservice";
        public string GetVehicleServiceByVehicleId => HostName + "api/vehicleservicebyvehicleid";
        
        public string UpdateVehicleService => HostName + "api/updatevehicleservice";
        public string DeleteVehicleService => HostName + "api/deletevehicleservice";
        
        public string GetToken => HostName + "token";
        public string LogInUser => HostName + "api/values/getvalues";


    }
}
