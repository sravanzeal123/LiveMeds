using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /AdminHome/
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                IEnumerable<Product> products = ServiceFactory.GetProductService().GetAll();
                IEnumerable<Product> TopProducts = ServiceFactory.GetProductService().GetAll().OrderByDescending(p => p.ProductSold).Take(5);
                ViewBag.TopProducts = TopProducts;

                double TotalSell = 0;
                double TotalBuy = 0;
                foreach (var product in products)
                {
                    TotalSell += (product.ProductSold + product.ProductQuantity) * product.ProductSellingPrice;
                    TotalBuy += (product.ProductSold + product.ProductQuantity) * product.ProductBuyingPrice;
                }
                ViewBag.totalSell = TotalSell;
                ViewBag.totalBuy = TotalBuy;
                ViewBag.products = products;

                IEnumerable<Order> orders = ServiceFactory.GetOrderService().GetAll("false");
                IEnumerable<Order> delivery = ServiceFactory.GetOrderService().GetAll("true");
                int TotalDelivery = delivery.Count();
                int TotalOrder = orders.Count();
                ViewBag.totalDelivery = TotalDelivery;
                ViewBag.totalOrder = TotalOrder;

                return View((Admin)Session["Admin"]);
            }

                
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
	}
}