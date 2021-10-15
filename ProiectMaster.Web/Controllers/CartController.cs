using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMaster.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService service;

        public CartController(IProductService productService)
        {
            service = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = service.GetAllProducts();
            return View(products);
        }
    }
}
