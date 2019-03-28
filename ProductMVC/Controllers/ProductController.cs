using DomainCore.Products;
using Ninject;
using ProductMVC.JsonHelpers;
using ServiceCore.Abstraction.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;

        public ProductController()
        {
            productService = Infrastructure.DependencyResolver.Kernel.Get<IProductService>();
        }

        // GET: Product
        public ActionResult Index()
        {
            var productResponse = productService.GetProducts();
            if(productResponse.Success)
            {
                var items = productResponse?.Products ?? new List<Product>();
                return View("~/Views/Product/ProductList.cshtml", items);
            }

            return View("~/Views/Product/ProductList.cshtml", null);
        }

        public ActionResult Edit(int? id)
        {
            if(id != null)
            {
                var productFromDb = productService.GetProduct(id.Value)?.Product;
                if(productFromDb != null)
                {
                    return View("~/Views/Product/ProductEdit.cshtml", productFromDb);
                } else
                {
                    return View("~/Views/Product/ProductEdit.cshtml", new Product());
                }
            } else
            {
                return View("~/Views/Product/ProductEdit.cshtml", new Product());
            }
        }

        [HttpPost]
        public ActionResult EditPost(Product product)
        {
            if (ModelState.IsValid)
            {
                var productExists = product?.Id ?? 0;
                if(productExists > 0)
                {
                    var response = productService.Update(product);
                    if(response.Success)
                    {
                        var products = this.LoadProducts();
                        var productInList = products.FirstOrDefault(x => x.Id == product.Id);
                        if (productInList != null)
                            products.Remove(productInList);
                        products.Add(response.Product);
                        this.SaveProducts(products);
                    }
                } else
                {
                    var response = productService.Create(product);
                    if (response.Success)
                    {
                        var products = this.LoadProducts();
                        products.Add(response.Product);
                        this.SaveProducts(products);
                    }
                }


                return Redirect("/Product");
            }
            return Redirect("/Product/Edit/" + (product?.Id.ToString() ?? ""));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if(id < 1)
                return Redirect("/Product");

            var response = productService.Delete(new Product() { Id = id });
            if (response.Success)
            {
                var products = this.LoadProducts();
                var productInList = products.FirstOrDefault(x => x.Id == id);
                if (productInList != null)
                    products.Remove(productInList);

                this.SaveProducts(products);
            }

            return Redirect("/Product");
        }
    }
}