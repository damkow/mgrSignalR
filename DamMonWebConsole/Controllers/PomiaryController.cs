using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DamMonWebConsole.Models;
using DamMonWebConsole.Hubs;
using DamMonWebConsole.DAL;

namespace DamMonWebConsole.Controllers
{
    public class PomiaryController : Controller
    {
        DamMonDatContext db = new DamMonDatContext();
        public JsonResult MonitorZapiszPomiar(string serwer, string cpu, string ram, string dysk, string data)
        {
            Pomiar pomiar = new Pomiar();
            pomiar.NazwaSerwera = serwer;
            pomiar.CzasProcesora = float.Parse(cpu);
            pomiar.DataCzasProbki = Convert.ToDateTime(data);
            pomiar.DostepnaPamiec = float.Parse(ram);
            pomiar.SredniaDlugoscKolejkiDyski = float.Parse(dysk);
            Serwer srv = db.Serwery.First(s => s.Nazwa == pomiar.NazwaSerwera);
            pomiar.SerwerID = srv.ID;
            db.Pomiary.Add(pomiar);
            db.SaveChanges();
            PomiaryHub.WyslijPomiary(pomiar);
            //PomiaryHub.WyslijPomiary();
            OdpowiedzMonitor odp = new OdpowiedzMonitor();
            odp.serwer = serwer;
            odp.status = "ok";
            return Json(odp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
        // GET: Pomiary
        public ActionResult Indexjq()
        {
            var listaSerw = db.Serwery;
            return View(listaSerw);
        }
        public ActionResult Indexwp()
        {
            var listaSerw = db.Serwery;
            return View(listaSerw);
        }

        public string PobierzProbki(string serwer)
        {
            
            string ret = "";
            var pomiaryLista = db.Pomiary.Where(p => p.NazwaSerwera == serwer).OrderByDescending(p => p.ID).Take(1);
            foreach (Pomiar item in pomiaryLista)
            {
                ret = serwer+";"+ item.CzasProcesora.ToString() + ";" + item.SredniaDlugoscKolejkiDyski.ToString() + ";" + item.DostepnaPamiec.ToString() + ";" + item.DataCzasProbki.ToString();
            }
            if (pomiaryLista.Count()==0)
            {
                ret = serwer + ";0;0;0;0";
            }
            return ret;
        }
    }
}