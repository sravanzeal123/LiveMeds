using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Live_Meds.Models
{
    public class PrescriptionProductModel
    {
        public String name { get; set; }
        public Prescription Prescription { get; set; }
        public List<Product> Products {get;set;}
        public PrescriptionProductModel()
        {
            Products = new List<Product>();
           
       }
    }
}