using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VehicleRegister.Domain.VehicleService.Interfaces;

namespace VehicleRegister.MVC.Models
{
    public class VehicleModel
    {
        [Display(Name = "Vehicleid:")]
        public int VehicleId { get; set; }
        [Required]
        [Display(Name = "Registrationnumber:")]
        public string RegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Model:")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Brand:")]
        public string Brand { get; set; }
        [Display(Name = "Vehicletype:")]
        public string VehicleType { get; set; }
        [Required]
        [Display(Name = "Weight:")]
        public double Weight { get; set; }
        [Display(Name = "Yearly fee:")]
        public double YearlyFee { get; set; }
        [Display(Name = "Booked service:")]
        public IVehicleService BookedService { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "First use in traffic:")]
        public DateTime FirstUseInTraffic { get; set; }
        [Required]
        [Display(Name = "Is vehicle registered:")]
        public bool? IsRegistered { get; set; }

    }
    
    public class DeleteVehicleModel
     {       
        [Display(Name = "Vehicle Id:")]
        public int VehicleId { get; set; }
        [Display(Name = "Regestrationnumber:")]
        public string RegistrationNumber { get; set; }
    }

     public class GetVehicleByIdModel
     {
        [Display(Name = "Vehicle Id:")]
        public int VehicleId { get; set; }
     }

     public class UpdateVehicleModel
     {
        [Editable(false)]
        [Display(Name = "Vehicleid:")]
        public int VehicleId { get; set; }
        [Required]
        [Display(Name = "Registrationnumber:")]
        public string RegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Model:")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Brand:")]
        public string Brand { get; set; }
        [Editable(false)]
        [Display(Name = "Vehicletype:")]
        public string VehicleType { get; set; }
        [Editable(false)]
        [Required]
        [Display(Name = "Weight:")]
        public double Weight { get; set; }
        [Editable(false)]
        [Display(Name = "Yearly fee:")]
        public double YearlyFee { get; set; }
        [Display(Name = "Booked service:")]
        public IVehicleService BookedService { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "First use in traffic:")]
        public DateTime FirstUseInTraffic { get; set; }
        [Required]
        [Display(Name = "Is vehicle registered:")]
        public bool? IsRegistered { get; set; }
    }

}