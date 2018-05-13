using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetCategoryService().GetAll());
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
        public ActionResult Create(Category category)
        {
            if (ServiceFactory.GetCategoryService().Insert(category) > 0)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Details(int id)
        {
            Category category = ServiceFactory.GetCategoryService().Get(id);
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = ServiceFactory.GetCategoryService().Get(id);
            return View(category);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            int i = ServiceFactory.GetCategoryService().Update(category);
            return RedirectToAction("Index");

        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = ServiceFactory.GetCategoryService().Get(id);
            return View(category);
        }
        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            
            if (ServiceFactory.GetCategoryService().Delete(id) > 0)
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