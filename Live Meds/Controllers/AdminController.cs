using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View(ServiceFactory.GetAdminService().GetAll());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ServiceFactory.GetAdminService().Insert(admin)> 0)
            {
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(admin);
            }
        }
        public ActionResult Details(int id)
        {
            Admin admin = ServiceFactory.GetAdminService().Get(id);
            return View(admin);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            Admin admin = ServiceFactory.GetAdminService().Get(id);
            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            int i = ServiceFactory.GetAdminService().Update(admin);
            return RedirectToAction("Index");
           
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Admin admin = ServiceFactory.GetAdminService().Get(id);
            return View(admin);
        }
        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
           
            if (ServiceFactory.GetAdminService().Delete(id)> 0)
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