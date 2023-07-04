using MechanicShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MechanicShopApp.ViewModel
{
    public class BookAppointmentViewModel
    {
        public IEnumerable<Service> Services { get; set; }
        public BookAppointment BookAppointment { get; set; }
    }
}