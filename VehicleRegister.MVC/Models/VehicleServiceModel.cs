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
        [Display(Name = "Date of Service:")]
        public DateTime ServiceDate { get; set; }
        [Required]
        [Display(Name = "Describe the type of service:")]
        public string ServiceType { get; set; }
    }
}