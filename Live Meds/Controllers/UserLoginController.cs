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
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
            if (IsUser(model))
            {

                if (Session["Cart"] != null)
                {
                    return RedirectToAction("Cart", "Home");
                }
                ViewBag.User = "";
                return RedirectToAction("ProductList", "Home");
            }


            else
            {
                ViewBag.User = "USER DOES NOT EXIST OR USERNAME PASSWORD MISMATCH";
            }
            return View();
        }


        bool IsUser(UserLoginModel model)
        {
            User user = ServiceFactory.GetUserService().GetByUserName(model.UserName);
           

            if (user != null && user.Password.Equals(model.Password))
            {
                Session["User"] = user;
                int id = user.UserId;
                string name = user.Name;
                Session["id"] = id;
                Session["name"] = name;
                return true;
            }
            else
                return false;
        }
    }
}