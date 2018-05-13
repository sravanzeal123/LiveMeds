using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveMedsEntity
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public string PrescriptionCategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}