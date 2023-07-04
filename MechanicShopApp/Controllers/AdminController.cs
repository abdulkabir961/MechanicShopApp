using MechanicShopApp.Models;
using MechanicShopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MechanicShopApp.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Admin
        

        public ActionResult ListBookings()
        {
            var bookappointment = db.BookAppointments.Include(c => c.Service);
            return View(bookappointment.ToList());
        }

        //GET: BookAppointments/Create
        public ActionResult Create()
        {
            var service = db.Services.ToList();
            var viewModel = new BookAppointmentViewModel
            {
                Services = service
            };
            return View(viewModel);
        }

        //POST: BookAppointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAppointment bookAppointment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookAppointmentViewModel
                {
                    BookAppointment = bookAppointment,
                    Services = db.Services.ToList()
                };
                return View("Create", viewModel);
            }

            if (bookAppointment.BookAppointmentId == 0)
                db.BookAppointments.Add(bookAppointment);
            db.SaveChanges();



            return RedirectToAction("Responses", "BookAppointments");


        }

        //GET: Customers/Detail/id
        public ActionResult Details(int? BookAppointmentId)
        {
            if (BookAppointmentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bookappointment = db.BookAppointments.Include(c => c.Service);
            BookAppointment bookAppointment = db.BookAppointments.Find(BookAppointmentId);
            if (bookAppointment == null)
            {
                return HttpNotFound();
            }
            return View(bookAppointment);
        }
    }
}