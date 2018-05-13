using LiveMedsData;
using LiveMedsService.Interfaces;
using LiveMedsService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMedsService
{
    public abstract class ServiceFactory
    {
        public static IAdminService GetAdminService ()
        {
            return new AdminService(DataAccessFactory.GetAdminDataAccess());
        }

        public static ICategoryService GetCategoryService()
        {
            return new CategoryService(DataAccessFactory.GetCategoryDataAccess());
        }

        public static IDeliveryService GetDeliveryService()
        {
            return new DeliveryService(DataAccessFactory.GetDeliveryDataAccess());
        }


        public static IProductService GetProductService()
        {
            return new ProductService(DataAccessFactory.GetProductDataAccess());
        }
        public static IOrderService GetOrderService()
        {
            return new OrderService(DataAccessFactory.GetOrderDataAccess());
        }
        public static IUserService GetUserService()
        {
            return new UserService(DataAccessFactory.GetUserDataAccess());
        }
        public static IManufacturerService GetManufacturerService()
        {
            return new ManufacturerService(DataAccessFactory.GetManufacturerDataAccess());
        }
        public static IPrescriptionService GetPrescriptionService()
        {
            return new PrescriptionService(DataAccessFactory.GetPrescriptionDataAccess());
        }
        
    }
}
