using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProject.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            
            ViewBag.Info = new List<string>(){
                "hej",
                "med",
                "dig"
            };
           
            return View();
        }
    }
}