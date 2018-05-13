using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetOrderService().GetAll("false"));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           
        }

        public ActionResult UserOrder()
        {
            return View(ServiceFactory.GetOrderService().GetAll("false").Where(e => e.UserId.Equals(Session["id"])));
        }

        public ActionResult Details(int id)
        {
            return View(ServiceFactory.GetOrderService().Get(id).Products);
        }

        public ActionResult Delivered(int id)
        {
            Order order = ServiceFactory.GetOrderService().Get(id);
            order.Delivered = "true";
            Console.WriteLine(ServiceFactory.GetOrderService().Update(order));
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Order p = ServiceFactory.GetOrderService().Get(id);
            return View(p);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ServiceFactory.GetOrderService().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}