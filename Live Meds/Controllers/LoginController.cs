using Live_Meds.Models;
using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (IsAdmin(model))
            {
                ViewBag.User = "";
                return RedirectToAction("Index", "AdminHome");
            }
            else if (IsUser(model))
            {
                ViewBag.User = "";
            }

            else
            {
                ViewBag.User = "USER DOES NOT EXIST OR USERNAME PASSWORD MISMATCH";
            }
            return View();
        }

        bool IsAdmin(LoginModel model)
        {
            Admin user = ServiceFactory.GetAdminService().GetByUserName(model.UserName);
            if (user != null && user.AdminPassword.Equals(model.Password))
            {
                Session["Admin"] = user;
                return true;
            }
            else
                return false;
        }

        bool IsUser(LoginModel model)
        {
            User user = ServiceFactory.GetUserService().GetByUserName(model.UserName);
            if (user != null && user.Password.Equals(model.Password)) return true;
            else
                return false;
        }
	}
}