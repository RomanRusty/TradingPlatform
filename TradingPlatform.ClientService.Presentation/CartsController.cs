
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Modals;
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
        //public async Task<IActionResult> ProductDetails(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Repository<Product>().FindByIdAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    SelectList orderSelectList = null;

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        IEnumerable<Order> orders = _context.Repository<Order>().FindAll(t => t.Status == OrderStatus.Selecting && t.Custumer.UserName == User.Identity.Name);
        //        orderSelectList = new SelectList(orders, "Id", "Name");
        //    }
        //    return View(new ProductModel() { Product = product, AvailableOrdersSelectList = orderSelectList });
        //}

        //public async Task<IActionResult> DeleteOrder(int id)
        //{
        //    var order = await _context.Repository<Order>().FindByIdAsync(id);
        //    await _context.Repository<Order>().RemoveAsync(order);
        //    return RedirectToAction(nameof(Index));
        //}

        //public async Task<IActionResult> DeleteProductOrder(int id)
        //{
        //    var productOrder = await _context.Repository<ProductOrder>().FindByIdAsync(id);
        //    await _context.Repository<ProductOrder>().RemoveAsync(productOrder);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}


