
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Presentation
{
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }

        public async Task<IActionResult> Index()
        {
            var index = await _cartService.IndexAsync();

            return View(index);
        }
        public async Task<IActionResult> AddProductToOrder(int productId)
        {
            var addItemToCartViewModel = await _cartService.AddProductToOrderAsync(productId);

            return PartialView("_ModalAddItemToCart",addItemToCartViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProductToOrder(ProductOrderCreateDto productOrder)
        {
            if (ModelState.IsValid)
            {
                await _cartService.AddProductToOrderAsync(productOrder);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DeleteProductFromOrder(int id)
        {
            await _cartService.DeleteProductFromOrder(id);

            return (RedirectToAction("Index"));
        }
    }
}


