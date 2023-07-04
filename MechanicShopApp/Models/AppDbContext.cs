using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MechanicShopApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("StringDBContext")
        {

        }
        public DbSet<BookAppointment> BookAppointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}