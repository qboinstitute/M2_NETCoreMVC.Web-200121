using M2_NETCoreMVC.Web.Areas.Marketing.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProductsWithViewModel()
        {
            var products = GetProductsJsonLocal(); 
            return View("Products",products);
        }

        public IActionResult ProductsWithViewData()
        {
            var products = GetProductsJsonLocal();
            ViewData["ProductList"] = products;
            //ViewData["Titulo"] = "asdasdas"
            return View("ProductsVD");
        }

        public async Task<IActionResult> ProductsWithViewBag()
        {
            var products = await GetProductsJsonRemote();//GetProductsJsonLocal();
            ViewBag.Titulo = "Este es un titulo ProductsWithViewBag";
            ViewBag.ProductList = products;

            return View("ProductsVB");
        }

        public IEnumerable<Product> GetProductsJsonLocal()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Areas\\Marketing\\Data\\Products.json");
            var json = System.IO.File.ReadAllText(folderDetails);
            IEnumerable<Product> products =
                JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsJsonRemote()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://raw.githubusercontent.com/dotnet-presentations/ContosoCrafts/master/src/wwwroot/data/products.json");
            string apiResponse = await response.Content.ReadAsStringAsync();
            IEnumerable<Product> products =
               JsonConvert.DeserializeObject<IEnumerable<Product>>(apiResponse);

            return products;
        }

    }
}
