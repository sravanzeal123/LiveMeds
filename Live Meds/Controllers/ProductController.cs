using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Live_Meds.Models;

namespace Live_Meds.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            if ((Admin)Session["Admin"] != null)
            {
                return View(ServiceFactory.GetProductService().GetAll());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            ProductCategoryManufacturerModel test = new ProductCategoryManufacturerModel();
            test.Categories = ServiceFactory.GetCategoryService().GetAll();
            test.Manufactures = ServiceFactory.GetManufacturerService().GetAll();
            //test.CategoryId = 2;
            return View(test);
        }
        [HttpPost]
        public ActionResult Create(ProductCategoryManufacturerModel p, HttpPostedFileBase ImagePath)
        {

            if (ModelState.IsValid)
            {
                string pic_name = p.Product.ProductName + Path.GetExtension(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic_name);

                ImagePath.SaveAs(path);

                // tyre.Url = filename;
                //p.ImagePath = DateTime.Now.ToLongDateString() + p.productId;
                p.Product.ProductImagePath = "~/Images/" + pic_name;
                p.Product.CategoryId = p.CategoryId;
                p.Product.ManufacturerId = p.ManufacturerId;
                int r = ServiceFactory.GetProductService().Insert(p.Product);
               
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }

        }

        public ActionResult Edit(int id)
        {
            Product p = ServiceFactory.GetProductService().Get(id);
            ProductCategoryManufacturerModel test = new ProductCategoryManufacturerModel();
            test.Categories = ServiceFactory.GetCategoryService().GetAll();
            test.Manufactures = ServiceFactory.GetManufacturerService().GetAll();
            test.Product = p;
            test.ManufacturerId = p.ManufacturerId;
            test.CategoryId = p.CategoryId;
            return View(test);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategoryManufacturerModel p, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                //Product pToUpdate = ServiceFactory.GetProductService().Get(p.Product.ProductId);
                try
                {
                    string fullPath = Request.MapPath(p.Product.ProductImagePath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    string pic_name = p.Product.ProductName + Path.GetExtension(ImagePath.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic_name);

                    ImagePath.SaveAs(path);

                    // tyre.Url = filename;
                    //p.ImagePath = DateTime.Now.ToLongDateString() + p.productId;
                    
                    p.Product.ProductImagePath = "~/Images/" + pic_name;
                   // pToUpdate.ProductImagePath = p.Product.ProductImagePath;

               }
                catch (Exception ex)
                {

                }


             

                ///context.SaveChanges();

               // p.Product.ProductId = 17;
                p.Product.CategoryId = p.CategoryId;
                p.Product.ManufacturerId = p.ManufacturerId;
                
                ServiceFactory.GetProductService().Update(p.Product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Details(int id)
        {
            Product p = ServiceFactory.GetProductService().Get(id);
            //p.Category = ServiceFactory.GetCategoryService().Get(p.CategoryId);
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            Product p = ServiceFactory.GetProductService().Get(id);
            return View(p);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                string ImagePath = ServiceFactory.GetProductService().Get(id).ProductImagePath;
                int i = ServiceFactory.GetProductService().Delete(id);
               
                string fullPath = Request.MapPath(ImagePath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}