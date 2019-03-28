using ServiceCore.Abstraction.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace ProductMVC.Controllers
{
    public class HomeController : Controller
    {
        //IProductService productService;

        public HomeController()
        {
            //productService = Infrastructure.DependencyResolver.Kernel.Get<IProductService>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}