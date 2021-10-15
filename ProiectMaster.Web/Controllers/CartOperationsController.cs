using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectMaster.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartOperationsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartOperationsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Route("Add/{id}")]
        public IActionResult Add(int id, int quantity = 1)
        {
            _cartService.AddToCart(1, id, quantity);
            return RedirectToAction("Details", "", id);
        }
    }
}
