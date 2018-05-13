using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveMedsEntity
{

    public class Order
    {

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public double Total { get; set; }
        public string OrderTime { get; set; }
        public List<Item> Products { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public string Delivered { get; set; }
    }



}