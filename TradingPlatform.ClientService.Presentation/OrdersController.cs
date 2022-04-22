using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Presentation
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.IndexAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _orderService.DetailsAsync(id));
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] OrderCreateDto orderCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _orderService.CreatePostAsync(orderCreateDto);
                if (User.IsInRole(UserRoles.Admin))
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(orderCreateDto);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _orderService.EditGetAsync(id));
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] OrderCreateDto orderCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _orderService.EditPostAsync(id, orderCreateDto);
                if (User.IsInRole(UserRoles.Admin))
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index),"Home");
            }
            return View(orderCreateDto);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.DetailsAsync(id);

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.DeleteAsync(id);
            if (User.IsInRole(UserRoles.Admin))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), "Carts");
        }
    }
}
