using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveMedsEntity
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string DeliveryTime { get; set; }
        public List<Order> Orders { get; set; }
    }
}