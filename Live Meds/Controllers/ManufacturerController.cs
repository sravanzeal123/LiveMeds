using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Live_Meds.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: Manufacturer
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetManufacturerService().GetAll());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        // GET: Manufacturer/Details/5
        public ActionResult Details(int id)
        {
            return View(ServiceFactory.GetManufacturerService().Get(id));
        }

        // GET: Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufacturer/Create
        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            try
            {
                // TODO: Add insert logic here
                ServiceFactory.GetManufacturerService().Insert(manufacturer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manufacturer/Edit/5
        public ActionResult Edit(int id)
        {
            Manufacturer manufacturer = ServiceFactory.GetManufacturerService().Get(id);
            return View(manufacturer);
        }

        // POST: Manufacturer/Edit/5
        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            try
            {
                // TODO: Add update logic here
                ServiceFactory.GetManufacturerService().Update(manufacturer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manufacturer/Delete/5
        public ActionResult Delete(int id)
        {
            Manufacturer manufacturer = ServiceFactory.GetManufacturerService().Get(id);
            return View(manufacturer);
        }

        // POST: Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ServiceFactory.GetManufacturerService().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
