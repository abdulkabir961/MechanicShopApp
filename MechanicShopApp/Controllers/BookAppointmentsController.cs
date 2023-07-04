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
    public class BookAppointmentsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: BookAppointments
        public ActionResult Index()
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

        public ActionResult Responses()
        {
            
            return View();
        }

    }
}