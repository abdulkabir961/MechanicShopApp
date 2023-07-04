using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MechanicShopApp.Models
{
    public class BookAppointment
    {

        [Key]
        public int BookAppointmentId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }

        public Service Service { get; set; }

        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        public string Message { get; set; }
    }
}