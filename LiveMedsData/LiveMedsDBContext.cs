using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LiveMedsData
{
    public class LiveMedsDBContext : DbContext
    {
        //public DbSet<Product> Products { get; set; }
        //public DbSet <Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manufacturer> Manufactureres { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Delivery> Deliveries { get; set; }
       // public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Manufacturer> Manufactureres { get; set; }
       public DbSet<Prescription> Prescriptions { get; set; }
        
    }
}