using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MechanicShopApp.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Rate { get; set; }

        public decimal Amount { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}