using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRegister.MVC.Models
{
    public class VehicleServiceModel
    {
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

    }

    public class UpdateVehicleServiceModel
    {

    }

    public class GetVehicleServiceById
    {

    }

    public class GetAllVehicleServices
    {
        //En för aktiva
        //En för historia
        //En för specifikt fordons historia
    }
}