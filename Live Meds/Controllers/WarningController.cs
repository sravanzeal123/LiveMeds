using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class WarningController : Controller
    {
        // GET: Warning
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetProductService().GetAll().Where(p => p.ProductQuantity < 10));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
    }
}