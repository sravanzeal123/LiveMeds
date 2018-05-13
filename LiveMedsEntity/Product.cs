using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveMedsEntity
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductBuyingPrice { get; set; }
        public double ProductSellingPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductSold { get; set; }
        public string ProductImagePath { get; set; }
        public string ProductFormulation { get; set; }
        public string ProductPackagingType { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        //public List<Order> Orders { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        // public List<Item> Items { get; set; }
       
        
    }
}