using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Home;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.Presentation
{
    public class HomeController : Controller {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService ?? throw new ArgumentNullException(nameof(homeService));
        }

        public async Task<IActionResult> Index(string sortOrder, string sortDirection, string currentFilter, string searchString, string category, int page)
        {
            IndexViewModel indexViewModel = await _homeService.IndexAsync( sortOrder, sortDirection, currentFilter, searchString, category, page);

            return View(indexViewModel);
        }
        [Authorize(Roles ="Custumer")]
        public async Task<IActionResult> BecomeSeller()
        {
            await _homeService.BecomeSeller();

            return RedirectToAction("Index");
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
        //    //return View(new ProductDetailsViewModel() { Product = product, AvailableOrdersSelectList = orderSelectList });
        //    return View();
        //}
        //public IActionResult CreateOrder()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateOrder([Bind("Id,Name")] Order order)
        //{
        //    string curUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    order.Custumer = _context.Repository<ApplicationUser>().FindById(curUserId);
        //    order.CreationDate = DateTime.Today;
        //    order.Status = OrderStatus.Selecting;
        //    if (ModelState.IsValid)
        //    {
        //        await _context.Repository<Order>().AddAsync(order);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(order);
        //}
    }
}