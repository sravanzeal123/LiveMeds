using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetUserService().GetAll());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Create()

        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            ServiceFactory.GetUserService().Insert(user);
            return View();
        }

        public ActionResult Delete(int id)
        {
            
            return View(ServiceFactory.GetUserService().Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {

            if (ServiceFactory.GetUserService().Delete(id) > 0)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }


        }
	}
}