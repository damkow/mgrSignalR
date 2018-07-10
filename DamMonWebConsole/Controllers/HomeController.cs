using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DamMonWebConsole.Models;
using DamMonWebConsole.Hubs;

namespace DamMonWebConsole.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        
        public JsonResult TestReq(string serwer)
        {
            OdpowiedzMonitor odp = new OdpowiedzMonitor();
            odp.serwer = serwer;
            odp.status = "ok";
            return Json(odp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        
    }
}