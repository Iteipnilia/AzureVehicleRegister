using System;
using System.ComponentModel.DataAnnotations;


namespace VehicleRegister.MVC.Models
{
    public class VehicleServiceModel
    {
        [Required]
        [Display(Name = "Vehicle id:")]
        public int VehicleId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Service:")]
        public DateTime ServiceDate { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Describe the type of service:")]
        public string ServiceType { get; set; }
    }
    public class DeleteVehicleServiceModel
    {
        [Display(Name = "Vehicleservice id:")]
        public int VehicleServiceId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Service:")]
        public DateTime ServiceDate { get; set; }
        [Display(Name = "Vehicle id:")]
        public int VehicleId { get; set; }
        [Display(Name = "Vehicle registrationnnumber:")]
        public int VehicleRegistrationNumber { get; set; }

    }

    public class UpdateVehicleServiceModel
    {
        [Required]
        [Display(Name = "Vehicleservice id:")]
        public int VehicleServiceId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Service:")]
        public DateTime ServiceDate { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Type of service:")]
        public string ServiceType { get; set; }
        [Required]
        [Display(Name = "Is service complete?:")]
        public bool? IsServiceCompleted { get; set; }
    }

    public class GetVehicleServicesModel
    {
        [Required]
        [Display(Name = "Vehicleservice id:")]
        public int VehicleServiceId { get; set; }
        [Required]
        [Display(Name = "Vehicle id:")]
        public int VehicleId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Service:")]
        public DateTime ServiceDate { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Type of service:")]
        public string ServiceType { get; set; }
    }
}