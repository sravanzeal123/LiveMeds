using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsEntity
{
    public class Item
    {
        public int id { get; set; }
        //public Product product { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double ProductSellingPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public int ItemCount { get; set; }
        public double Total { get; set; }
        public void Calculate()
        {
            //id = product.ProductId;
            Total = ProductSellingPrice * ItemCount;
        }
    }
}
