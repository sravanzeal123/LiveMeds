using Live_Meds.Models;
using LiveMedsEntity;
using LiveMedsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Live_Meds.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //HtmlToPdfConverter htmlToPdfConverter = new HtmlToPdfConverter();

            //Set license key received after purchase to use the converter in licensed mode
            // Leave it not set to use the converter in demo mode
            //htmlToPdfConverter.LicenseKey = "4W9+bn19bn5ue2B+bn1/YH98YHd3d3c=";

            //Convert the HTML page to a PDF document in a memory buffer
            //byte[] outPdfBuffer = htmlToPdfConverter.ConvertUrl("http://localhost:6585/UserHome/Details/10#product-list");

            //Send the PDF as response to browser

            // Set response content type
            //Response.AddHeader("Content-Type", "application/pdf");

            //Instruct the browser to open the PDF file as an attachment or inline
            //Response.AddHeader("Content-Disposition", String.Format("attachment; filename=Partially_Convert_HTML.pdf; size={0}", outPdfBuffer.Length.ToString()));

            //Write the PDF document buffer to HTTP response
            //Response.BinaryWrite(outPdfBuffer);

            //End the HTTP response and stop the current page processing
            //Response.End();


            return View();
        }


        public ActionResult Details(int id)
        {
            Product product = ServiceFactory.GetProductService().Get(id);

            return View(product);
        }

        [HttpGet]
        public ActionResult UpdateCart(int id, int count)
        {
            Cart cart = (Cart)Session["Cart"];
            foreach (Item item in cart.Items)
            {
                if (item.ProductId == id)
                {
                    item.ItemCount = count;
                    item.Calculate();
                }
            }
            Session["Cart"] = cart;
            return RedirectToAction("Index");

        }

        public ActionResult AddtoCart(int id)
        {

            Product p = ServiceFactory.GetProductService().Get(id);
            Item item = new Item();
           // item.product = p;
            item.Name = p.ProductName;
            item.ProductId = p.ProductId;
            item.ProductSellingPrice = p.ProductSellingPrice;
            item.ProductQuantity = p.ProductQuantity;
            item.ItemCount = 1;
            item.Calculate();
            
            if (Session["Cart"] != null)
            {

                //taking the cart from the session
                Cart cart = (Cart)Session["Cart"];
                //checking if the product is already in cart
                //if exists increasing the count
                if (!DoesExist(p, cart))
                {
                    cart.Items.Add(item);
                    Session["item"] = cart.Items;
                    Session["Cart"] = cart;
                    Session["id"] = cart.Items.Count;
                    int count = Convert.ToInt32(Session["ItemCount"]);
                    count += 1;
                    Session["ItemCount"] = count;
                }
                //either adding to the cart
                else
                {
                    Item existing = cart.Items.SingleOrDefault(itm => itm.ProductId == p.ProductId);
                    existing.ItemCount++;
                    existing.Calculate();
                    Session["Cart"] = cart;
                    Session["id"] = cart.Items.Count;
                }
                

            }
            //if session is null then creating a cart
            else
            {
                Cart cart = new Cart();
                cart.Items.Add(item);
                Session["Cart"] = cart;
                Session["id"] = cart.Items.Count;
                int count = Convert.ToInt32(Session["ItemCount"]);
                count += 1;
                Session["ItemCount"] = count;
            }

            return RedirectToAction("ProductList");
        }
        //showing the cart
        public ActionResult ShowCart()
        {

            Cart cart = new Cart();
            if (Session["Cart"] != null) cart = (Cart)Session["Cart"];

            return View(cart.Items);
        }

        public ActionResult Cart()
        {
            Cart cart = new Cart();
            if (Session["Cart"] != null) cart = (Cart)Session["Cart"];

            return View(cart.Items);
        }
        //removing element from cart
        public ActionResult Remove(int id)
        {

            Cart cart = new Cart();
            if (Session["Cart"] != null) cart = (Cart)Session["Cart"];
            Item item = cart.Items.SingleOrDefault(e => e.ProductId == id);
            cart.Items.Remove(item);
            int count = Convert.ToInt32(Session["ItemCount"]);
            count -= 1;
            Session["ItemCount"] = count;
            if (!cart.Items.Any())
            {
                Session["Cart"] = null;
            }

            return RedirectToAction("Cart");
        }

        //function to check if product is already in the cart
        bool DoesExist(Product p, Cart cart)
        {
            bool result = false;
            foreach (Item item in cart.Items)
            {
                if (item.ProductId == p.ProductId)
                {
                    result = true;
                }
            }

            return result;
        }

        double CalculateTotal()
        {
            Cart cart = (Cart)Session["Cart"];
            double total = 0;
            if (cart != null)
            {

                foreach (Item item in cart.Items)
                {
                    total += item.Total;
                }
            }
            return total;
        }

        public ActionResult CheckOut()
        {
            Order order = new Order();
            order.DeliveryId = 1;
            order.OrderTime = DateTime.Now.ToString("dd-MM-yyyy h:mm:ss tt");
           // order.UserId = (int)Session["id"];
            User user = (User)Session["User"];
            if (user != null)
            {
                order.UserId = user.UserId;
                order.Total = CalculateTotal();
                order.Delivered = "false";
                List<Product> temp = new List<Product>();
                Cart cart = (Cart)Session["Cart"];
                order.Products = cart.Items;
                ServiceFactory.GetOrderService().Insert(order);

                foreach (Item item in cart.Items)
                {
                    Product product = ServiceFactory.GetProductService().Get(item.ProductId);
                    product.ProductQuantity -= item.ItemCount;
                    product.ProductSold += item.ItemCount;
                    ServiceFactory.GetProductService().Update(product);
                }

                Session["Cart"] = null;
                Session["ItemCount"] = 0;

                return RedirectToAction("ProductList");
            }

            else
            {
                return RedirectToAction("Index","UserLogin");
            }
           
            //order.UserId =1;
            
        }

        public ActionResult FeaturedCategory(int id)
        {

            return View("FeaturedProducts", ServiceFactory.GetProductService().GetAll().Where(e => e.CategoryId.Equals(id)));
        }

        public ActionResult OTC()
        {

            return View("FeaturedProducts", ServiceFactory.GetProductService().GetAll().Where(e => e.CategoryId.Equals(2)));
        }

        public ActionResult BabyAndMother()
        {

            return View("FeaturedProducts", ServiceFactory.GetProductService().GetAll().Where(e => e.CategoryId.Equals(3)));
        }

        public ActionResult Diabetes()
        {
            return View("FeaturedProducts", ServiceFactory.GetProductService().GetAll().Where(e => e.CategoryId.Equals(4)));
        }

        public ActionResult Prescriptions()
        {

            return View(ServiceFactory.GetPrescriptionService().GetAll());
        }

        public ActionResult FeaturedProducts(int id)
        {
            return View(ServiceFactory.GetPrescriptionService().Get(id).Products);
        }

        public ActionResult ProductList()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.Categories = ServiceFactory.GetCategoryService().GetAll().ToList();
            homeModel.Products = ServiceFactory.GetProductService().GetAll().ToList();

            return View(homeModel);
        }

        public ActionResult SearchProduct(String id)
        {
            HomeModel homeModel = new HomeModel();
            homeModel.Categories = ServiceFactory.GetCategoryService().GetAll().ToList();
            homeModel.Products = ServiceFactory.GetProductService().GetAll().Where(e => e.ProductName.Contains(id)).ToList();
            return View("ProductList", homeModel);
        }

        public ActionResult SearchByCategory(String id)
        {
            HomeModel homeModel = new HomeModel();
            homeModel.Categories = ServiceFactory.GetCategoryService().GetAll().ToList();
            homeModel.Products = ServiceFactory.GetProductService().GetAll().Where(e => e.Category.CategoryName.Contains(id)).ToList();
            return View("ProductList", homeModel);
        }

        public ActionResult SearchPrescription(String id)
        {
           
           
            return View("Prescriptions", ServiceFactory.GetPrescriptionService().GetAll().Where(e => e.PrescriptionCategoryName.Contains(id)).ToList());
        }

        public ActionResult FilterSearch(String id, String count)
        {
            List<Product> AllProduct = ServiceFactory.GetProductService().GetAll().Where(e => e.ProductQuantity > 0).ToList();
            List<Product> FeaturedProducts = new List<Product>();

            if (id != null)
            {

                switch (count)
                {

                    case "Category":
                        FeaturedProducts = AllProduct.Where(e => e.ProductName.ToLower().Contains(id.ToLower()) || e.Category.CategoryName.ToLower().Contains(id.ToLower()) || e.Manufacturer.ManufactureName.ToLower().Contains(id.ToLower())).ToList();
                        break;
                    case "Prescription":

                        break;

                }
                return View(FeaturedProducts);
            }



            else
            {
                return View(FeaturedProducts);
            }
        }
       
       
       

    }
}