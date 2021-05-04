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
        [Required]
        [Display(Name = "Registrationnumber:")]
        public string RegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Model:")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Brand:")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Weight:")]
        public double Weight { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "First use in traffic:")]
        public DateTime FirstUseInTraffic { get; set; }
        [Display(Name = "Is vehicle registered?:")]
        public bool IsRegistered { get; set; }

    }
   /* public class DetailVehicleModel
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string VehicleType { get; set; }
        public double Weight { get; set; }
        public bool IsRegistered { get; set; }
        public double YearlyFee { get; set; }
        public IVehicleService BookedService { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FirstUseInTraffic { get; set; }
    }
    public class DeleteVehicleModel
    {
        [Display(Name = "Vehicle Id:")]
        public int VehicleId { get; set; }
    }

    public class GetVehicleById
    {
        public int VehicleId { get; set; }
    }

    public class UpdateVehicleModel
    {

    }

    public class GetAllVehicles
    {

    }*/
}