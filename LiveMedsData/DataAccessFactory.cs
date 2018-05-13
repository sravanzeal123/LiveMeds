using LiveMedsData.DataAccessors;
using LiveMedsData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsData
{
    public abstract class DataAccessFactory
    {
        static LiveMedsDBContext context = new LiveMedsDBContext();
        public static IAdminDataAccess GetAdminDataAccess ()
        {
            return new AdminDataAccess(context);
        }
        public static ICategoryDataAccess GetCategoryDataAccess()
        {
            return new CategoryDataAccess(context);
        }

        public static IDeliveryDataAccess GetDeliveryDataAccess()
        {
            return new DeliveryDataAccess(context);
        }

        public static IProductDataAccess GetProductDataAccess()
        {
            return new ProductDataAccess(context);
        }
        public static IOrderDataAccess GetOrderDataAccess()
        {
            return new OrderDataAccess(context);
        }

        public static IUserDataAccess GetUserDataAccess()
        {
            return new UserDataAccess(context);
        }
        public static IManufacturerDataAccess GetManufacturerDataAccess()
        {
            return new ManufacturerDataAccess(context);
        }

        public static IPrescriptionDataAccess GetPrescriptionDataAccess()
        {
            return new PrescriptionDataAccess(context);
        }
       
    }
}
