using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMaster.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = 0;//dummy initialize until users module is ready
            var cart = _cartService.GetCart(userId);
            if(cart == null)
            {
                return View(new CartVM());
            }

            var cartVM = new CartVM
            {
                ProductDTOs = cart.ProductIds.Select(x => new ProductDTO
                {
                    Id = x.ProductId,
                    Quantity = x.Quantity,
                    Name = _productService.GetProduct(x.ProductId).Name,
                    Price = _productService.GetProduct(x.ProductId).Price
                })
            };

            return View(cartVM);
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            _cartService.RemoveFromCart(1, id, 1);

            return RedirectToAction("Index");
        }
    }
}
