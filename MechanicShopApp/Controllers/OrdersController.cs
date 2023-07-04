using MechanicShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MechanicShopApp.Controllers
{
    public class OrdersController : Controller
    {
        private AppDbContext db = new AppDbContext();


        public ActionResult Index()
        {
            List<Customer> OrderAndCustomerList = db.Customers.ToList();
            return View(OrderAndCustomerList);
        }

        public ActionResult SaveOrder(string name, string address, Order[] order)
        {
            string result = "Error! order is Not Completed";
            if (name != null || address != null || order != null)
            {

                Customer model = new Customer();
                model.Name = name;
                model.Address = address;
                model.OrderDate = DateTime.Now;
                db.Customers.Add(model);
                foreach (var item in order)
                {

                    Order O = new Order();
                    O.Description = item.Description;
                    O.Quantity = item.Quantity;
                    O.Rate = item.Rate;
                    O.Amount = item.Amount;
                    O.CustomerId = item.CustomerId;
                    db.Orders.Add(O);
                }
                db.SaveChanges();
                result = "Success! order is Completed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}