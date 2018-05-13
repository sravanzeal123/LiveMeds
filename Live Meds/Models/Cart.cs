using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Live_Meds.Models
{
    public class Cart
    {
        public List<Item> Items { get; set; }
        public Cart()
        {
            Items = new List<Item>();
        }
    }
}