using MechanicShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MechanicShopApp.Controllers
{
    public class FeedbacksController : Controller
    {
        
        // GET: Feedbacks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendFeedback(Feedback model)
        {

            using (MailMessage mm = new MailMessage("testapp2218@gmail.com", model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;

                mm.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    NetworkCredential cred = new NetworkCredential("testapp2218@gmail.com", "xqdychrcvrmzxoys");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = cred;
                    smtp.Port = 587;

                    smtp.Send(mm);

                    ViewBag.Message = "Mail has been Sent Successfuly!";
                }
            }

                    return View();
        }

    }
}