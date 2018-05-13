using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Live_Meds.Models
{
    public class HomeModel
    {

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public HomeModel()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
        }
    }
}