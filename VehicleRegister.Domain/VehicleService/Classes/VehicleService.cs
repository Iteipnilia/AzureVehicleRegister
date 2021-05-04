using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.Domain.VehicleService.Classes
{
    class VehicleService : IVehicleService
    {
        private int serviceId { get; set; }
        private DateTime serviceDate { get; set; }
        private string serviceType { get; set; }
        private bool isServiceCompleted { get; set; }

        public int ServiceId => serviceId;
        public DateTime ServiceDate => serviceDate;
        public string ServiceType => serviceType;
        public bool IsServiceCompleted => isServiceCompleted;

        public VehicleService(int serviceId, DateTime serviceDate, string serviceType, bool isServiceCompleted)
        {
            this.serviceId = serviceId;
            this.serviceDate = serviceDate;
            this.serviceType = serviceType;
            this.isServiceCompleted = isServiceCompleted;
        }


        public void SetServiceCompleted()
        {
            isServiceCompleted = true;
        }

        public void ChangeServiceDate(DateTime dateTime)
        {
            serviceDate = dateTime;
        }
    }
}
