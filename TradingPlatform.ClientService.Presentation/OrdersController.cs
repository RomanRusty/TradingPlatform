using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Presentation
{
    public class OrdersController : ControllerBase
    {
        //private readonly IGenericUnitOfWork _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //public OrdersController(IGenericUnitOfWork context, IHttpContextAccessor httpContextAccessor)
        //{
        //    _context = context;
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //// GET: Orders
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Repository<Order>().GetAllAsync());
        //}

        //// GET: Orders/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Repository<Order>().FindByIdAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

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
                await ServiceManager.OrderService.CreatePostAsync(orderCreateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(orderCreateDto);
        }

        //// GET: Orders/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Repository<Order>().FindByIdAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate,Status")] Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _context.Repository<Order>().UpdateAsync(order);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!await _context.Repository<Order>().ExistsAsync(order.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(order);
        //}

        //// GET: Orders/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Repository<Order>().FindByIdAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var order = await _context.Repository<Order>().FindByIdAsync(id);
        //    await _context.Repository<Order>().RemoveAsync(order);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
