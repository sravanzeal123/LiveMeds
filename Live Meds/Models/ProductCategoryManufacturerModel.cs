using LiveMedsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Live_Meds.Models
{
    public class ProductCategoryManufacturerModel
    {
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Manufacturer> Manufactures { get; set; }
    }
}