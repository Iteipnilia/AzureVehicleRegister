using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleRegister.MVC.Controllers
{
    public class VehicleServiceController : Controller
    {
        // GET: VehicleService
        public ActionResult Index()
        {
            return View();
        }
    }
}