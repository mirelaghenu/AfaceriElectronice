using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.Interfaces;
using System.Collections.Generic;

namespace ProiectMaster.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICartService _cartService;

        public HomeController(IProductService productService, ICartService cartService)
        {
            this.productService = productService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = productService.GetAllProducts();
            PopulateCartNumber();
            return View(products);
        }

        private void PopulateCartNumber()
        {
            var cart = _cartService.GetCart(1);
            var sum = 0;
            foreach (var product in cart.ProductIds)
            {
                sum += product.Quantity;
            }
            HttpContext.Session.Set(SessionHelper.ShoppingCart, sum);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }
    }
}
