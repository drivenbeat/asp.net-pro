using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        
        // 자동으로 구현된 속성 사용하기 (get, setter)
        public ActionResult AutoProperty()
        {

            Product myProduct = new Models.Product();
            myProduct.Name = "Kayak";
            string productName = myProduct.Name;

            return View("Result", (object)String.Format("Product name: {0}", productName));
        }


        // 개체 및 컬렉션 이니셜라이저 사용하기
        public ViewResult CreateProduct()
        {

            //Product myProduct = new Product();
            //myProduct.ProductId = 100;
            //myProduct.Name = "Kayak";
            //myProduct.Description = "A boat for one person";
            //myProduct.Price = 265M;
            //myProduct.Category = "Watersports";


            Product myProduct = new Product
            {
                ProductId = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 265M,
                Category = "Watersports"
            };

            return View("Result", (object)string.Format("Category: {0}", myProduct.Category));
        }

        // 배열 컬랙션 사용 
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                {"apple", 10 }, {"orange", 20 }, {"plun", 30 }
            };

            return View("Result", (object)String.Format("{0}", myDict["orange"]));
        }

        // 확장 메서드 사용
        public ViewResult UseExtenstion()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Models.Product {Name = "Kayak", Price = 275M },
                    new Models.Product {Name = "Kayak", Price = 275M },
                    new Models.Product {Name = "Kayak", Price = 275M },
                    new Models.Product {Name = "Kayak", Price = 275M }
                }
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total : {0:c}", cartTotal));
        }
    }
}