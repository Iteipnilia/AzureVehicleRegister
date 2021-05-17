using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.Vehicle.Interfaces;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.Vehicle.Classes
{
    abstract class Vehicle : IVehicle
    {
        protected int vehicleId { get; set; }
        protected string registrationNumber { get; set; }
        protected string model { get; set; }
        protected string brand { get; set; }
        protected string vehicleType { get; set; }
        protected double weight { get; set; }
        protected bool? isRegistered { get; set; }
        protected double yearlyFee { get; set; }
        protected IVehicleService bookedService { get; set; }
        protected DateTime firstUseInTraffic { get; set; }
        protected List<IVehicleService> serviceHistory { get; set; }

        public int VehicleId => vehicleId;
        public string RegistrationNumber => registrationNumber;
        public string Model => model;
        public string Brand => brand;
        public string VehicleType => vehicleType;
        public double Weight => weight;
        public bool? IsRegistered => isRegistered;
        public double YearlyFee => yearlyFee;
        public IVehicleService BookedService => bookedService;
        public DateTime FirstUseInTraffic => firstUseInTraffic;
        public List<IVehicleService> ServiceHistory => serviceHistory;

        public Vehicle(int vehicleId, string registrationNumber, string model, string brand, 
                       double weight, bool? isRegistered, DateTime firstUseInTraffic)
        {
            this.vehicleId = vehicleId;
            this.registrationNumber = registrationNumber;
            this.model = model;
            this.brand = brand;
            this.weight = weight;
            this.isRegistered = isRegistered;
            this.firstUseInTraffic = firstUseInTraffic;
        }

        public void RegisterVehicle()
        {
            isRegistered = true;
        }

        public void UnregisterVehicle()
        {
            isRegistered = false;
        }

        public bool? CheckIfServiceIsCompleted(IVehicleService service)
        {
            return service.IsServiceCompleted;
        }

        public void AddNewBookedService(IVehicleService service)
        {
            if (bookedService != null) { throw new SystemException("There is already a service booked"); }

            else
                bookedService = service;
        }

        public void AddCompletedServiceToServiceHistory(IVehicleService service)
        {
            serviceHistory.Add(service);
        }
    }
}
