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
    public class PrescriptionController : Controller
    {
        
        PrescriptionProductModel prescrptionmodel = new PrescriptionProductModel();
       
        
        // GET: Prescription
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetPrescriptionService().GetAll());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int id)
        {

            return View(ServiceFactory.GetPrescriptionService().Get(id));
        }

        // GET: Prescription/Create
        public ActionResult Create()
        {
            prescrptionmodel.Products = ServiceFactory.GetProductService().GetAll().ToList();
            return View(prescrptionmodel);
        }

        // POST: Prescription/Create
        [HttpPost]
        public ActionResult Create(PrescriptionProductModel prescription)
        {
            Prescription p = new Prescription();
            p.PrescriptionCategoryName = prescription.name;
            if (Session["PrescriptionProduct"] != null)
            {
                List<Product> prescriptionProducts = (List<Product>)Session["PrescriptionProduct"];
                p.Products = prescriptionProducts;
        
            }
            int r = ServiceFactory.GetPrescriptionService().Insert(p);
                return RedirectToAction("Index");
           
        }

        // GET: Prescription/Edit/5
        public ActionResult Edit(int id)
        {
            
            prescrptionmodel.Prescription = ServiceFactory.GetPrescriptionService().Get(id);
            prescrptionmodel.Products = FilterProducts(ServiceFactory.GetProductService().GetAll().ToList(), prescrptionmodel.Prescription.Products);
            prescrptionmodel.name = prescrptionmodel.Prescription.PrescriptionCategoryName;
            Session["PrescriptionProduct"] = prescrptionmodel.Prescription.Products;
            Session["Prescription"] = prescrptionmodel.Prescription;
            return View(prescrptionmodel);
        }

        private List<Product> FilterProducts(List<Product> All, List<Product> PrescriptionProducts)
        {
            foreach (Product p in PrescriptionProducts)
            {
                if (DoesExist(All, p.ProductId))
                {
                    All.Remove(p);
                }
            }
            return All;
        }
        private bool DoesExist(List<Product> All, int id)
        {
            bool result = false;
            Product P = All.SingleOrDefault(pr => pr.ProductId == id);
            if (P != null) result = true;
            return result;
        }

        // POST: Prescription/Edit/5
        [HttpPost]
        public ActionResult Edit(PrescriptionProductModel prescription)
        {

            prescription.Prescription = (Prescription)Session["Prescription"];
            prescription.Prescription.PrescriptionCategoryName = prescription.name;

           // try
          //  {
                // TODO: Add update logic here
                ServiceFactory.GetPrescriptionService().Update(prescription.Prescription);
                return RedirectToAction("Index");
          //  }
           // catch
           // {
            //    return View();
          //  }
        }

        // GET: Prescription/Delete/5
        public ActionResult Delete(int id)
        {

            prescrptionmodel.Prescription = ServiceFactory.GetPrescriptionService().Get(id);
            prescrptionmodel.Products = FilterProducts(ServiceFactory.GetProductService().GetAll().ToList(), prescrptionmodel.Prescription.Products);
            prescrptionmodel.name = prescrptionmodel.Prescription.PrescriptionCategoryName;
            Session["Prescription"] = prescrptionmodel.Prescription;
            return View(prescrptionmodel);
        }

        // POST: Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                ServiceFactory.GetPrescriptionService().Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public String AddProduct(int id)
        {
            if (Session["PrescriptionProduct"] != null)
            {
                List<Product> prescriptionProducts = (List<Product>)Session["PrescriptionProduct"];
                prescriptionProducts.Add(ServiceFactory.GetProductService().Get(id));
                Session["PrescriptionProduct"] = prescriptionProducts;
                return prescriptionProducts.Count + " Count";

            }
            else
            {
                List<Product> prescriptionProducts = new List<Product>();
                prescriptionProducts.Add(ServiceFactory.GetProductService().Get(id));
                Session["PrescriptionProduct"] = prescriptionProducts;
                return prescriptionProducts.Count + " Count";
            }
           
            
           // return View("Create");
        }

        public String DeleteProduct(int id)
        {
            if (Session["PrescriptionProduct"] != null)
            {
                List<Product> prescriptionProducts = (List<Product>)Session["PrescriptionProduct"];
                Product product = prescriptionProducts.SingleOrDefault(pr => pr.ProductId == id);
                prescriptionProducts.Remove(product);
                Session["PrescriptionProduct"] = prescriptionProducts;
                return prescriptionProducts.Count + " Count";

            }

            return "";

            // return View("Create");
        }
    }
}
