using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.Interfaces;
using System.Collections.Generic;

namespace ProiectMaster.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = productService.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        [Route("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            var shopList = HttpContext.Session.Get<List<int>>(SessionHelper.ShoppingCart);

            if (shopList == null)
                return RedirectToAction("Index", "Home", productService.GetAllProducts());

            if (shopList.Contains(id))
                shopList.Remove(id);

            HttpContext.Session.Set(SessionHelper.ShoppingCart, shopList);

            return RedirectToAction("Index", "Home", productService.GetAllProducts());
        }
    }
}
