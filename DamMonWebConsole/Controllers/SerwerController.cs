using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DamMonWebConsole.DAL;
using DamMonWebConsole.Models;

namespace DamMonWebConsole.Controllers
{
    public class SerwerController : Controller
    {
        private DamMonDatContext db = new DamMonDatContext();

        // GET: Serwer
        public ActionResult Index()
        {
            return View(db.Serwery.ToList());
        }

        // GET: Serwer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serwer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa")] Serwer serwer)
        {
            if (ModelState.IsValid)
            {
                db.Serwery.Add(serwer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serwer);
        }

        // GET: Serwer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwer serwer = db.Serwery.Find(id);
            if (serwer == null)
            {
                return HttpNotFound();
            }
            return View(serwer);
        }

        // POST: Serwer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa")] Serwer serwer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serwer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serwer);
        }

        // GET: Serwer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwer serwer = db.Serwery.Find(id);
            if (serwer == null)
            {
                return HttpNotFound();
            }
            return View(serwer);
        }

        // POST: Serwer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serwer serwer = db.Serwery.Find(id);
            db.Serwery.Remove(serwer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Pomiary(int id)
        {
            var pomiary = db.Pomiary.Where(p => p.SerwerID == id);
            ViewBag.SerwerNazwa = db.Serwery.Find(id).Nazwa;
            return View(pomiary);
        }
    }
}
