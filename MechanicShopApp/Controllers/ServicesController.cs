using MechanicShopApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MechanicShopApp.Controllers
{
    public class ServicesController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Services
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        //GET:Services/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {

            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);

        }

        //GET: Services/Edit/id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //POST: Services/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        //GET: Services/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //POST: Services/Delete/id
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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
    }
}