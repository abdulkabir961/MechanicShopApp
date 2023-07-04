using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MechanicShopApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}