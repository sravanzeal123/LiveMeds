using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class DeliveryController : Controller
    {
        //
        // GET: /Delivery/
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetOrderService().GetAll("true"));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult Details(int id)
        {
            return View(ServiceFactory.GetOrderService().Get(id).Products);
        }

	}
}