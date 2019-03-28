using DomainCore.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC.JsonHelpers
{
    public static class JsonHelper
    {
        static string FileName = "ProductList.json";
        public static void SaveProducts(this Controller controller, List<Product> products) {
            try
            {
                var path = controller.HttpContext.Server.MapPath("~/" + FileName);

                string serialized = JsonConvert.SerializeObject(products);

                File.WriteAllText(path, serialized);
            } catch(Exception ex)
            {

            }
        }

        public static List<Product> LoadProducts(this Controller controller) {
            List<Product> products = new List<Product>();
            try
            {
                var path = controller.HttpContext.Server.MapPath("~/" + FileName);
                if (!File.Exists(path))
                    return products;


                var contents = File.ReadAllText(path);

                products = JsonConvert.DeserializeObject<List<Product>>(contents);

            } catch (Exception ex)
            {
                products = new List<Product>();
            }
            return products;
        }
    }
}