using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MechanicShopApp.Models
{
    public class Service
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Type")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}