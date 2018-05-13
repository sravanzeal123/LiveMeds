using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveMedsEntity
{

    public class Manufacturer
    {
   
        public int ManufacturerId { get; set; }
        public string ManufactureName { get; set; }
        public List<Product> Products { get; set; }
    }



}