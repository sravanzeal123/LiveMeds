using Live_Meds.Models;
using LiveMedsEntity;
using LiveMedsService;
using LiveMedsService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome

        public ActionResult Index()
        {
            if ((User)Session["User"] != null)
            {
                return View(ServiceFactory.GetUserService().GetAll().Where(e => e.UserId.Equals(Session["id"])));
            }
            else
            {
                return RedirectToAction("Index", "UserLogin");
            }

        }

        [HttpGet]
        public ActionResult ProfileEdit(int id)
        {
            User user = ServiceFactory.GetUserService().Get(id);
            UserModel u = new UserModel();
            u.Name = user.Name;
            u.Email = user.Email;
            return View(u);
        }
        [HttpPost]
        public ActionResult ProfileEdit(UserModel edit)
        {
            IUserService service = ServiceFactory.GetUserService();
            User user = service.Get(Convert.ToInt32(Session["id"]));
            user.Name = edit.Name;
            user.Email = edit.Email;
            service.Update(user);
            return RedirectToAction("Index");
        }
        // GET: UserHome/Details/5
        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["name"] = null;
            Session["User"] = null;
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: UserHome/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult UserOrder()
        {
            if ((User)Session["User"] != null)
            {
                return View(ServiceFactory.GetOrderService().GetAll("false").Where(e => e.UserId.Equals(Session["id"])));
            }
            else
            {
                return RedirectToAction("Index", "UserLogin");
            }
            
        }

        public ActionResult PurchaseHistory()
        {
            if ((User)Session["User"] != null)
            {
                return View(ServiceFactory.GetOrderService().GetAll("true").Where(e => e.UserId.Equals(Session["id"])));
            }
            else
            {
                return RedirectToAction("Index", "UserLogin");
            }
           
        }

        public ActionResult Details(int id)
        {
            return View(ServiceFactory.GetOrderService().Get(id).Products);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            if ((User)Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "UserLogin");
            }
            
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel change)
        {
            IUserService service = ServiceFactory.GetUserService();
            User user = service.Get(Convert.ToInt32(Session["id"]));
            if (user.Password == change.OldPassword && change.NewPassword == change.ConfirmPassword)
            {
                user.Password = change.NewPassword;
                service.Update(user);
                return RedirectToAction("Index");
            }

            else
            {
                ViewBag.Error = "Something went wrong";
            }

            return View();

        }

    }
}
