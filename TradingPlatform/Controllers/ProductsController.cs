using Microsoft.AspNetCore.Mvc;

namespace TradingPlatform.Controllers
{
    public class ProductsController : Controller
    {
        //    private readonly IGenericUnitOfWork _context;

        //    public ProductsController(IGenericUnitOfWork context)
        //    {
        //        _context = context;
        //    }

        //    // GET: Products
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _context.Repository<Product>().GetAllAsync());
        //    }

        //    // GET: Products/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var product = await _context.Repository<Product>().FindByIdAsync(id);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }
        //        SelectList orderSelectList = null;

        //        if (User.Identity.IsAuthenticated)
        //        {
        //            IEnumerable<Order> orders = _context.Repository<Order>().FindAll(t => t.Status == OrderStatus.Selecting && t.Custumer.UserName == User.Identity.Name);
        //            orderSelectList = new SelectList(orders, "Id", "Name");
        //        }
        //        return View(new ProductModel() { Product=product, AvailableOrdersSelectList= orderSelectList });
        //    }

        //    // GET: Products/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Products/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Quantity,CreationDate,ImageThumbnailPath")] Product product)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            await _context.Repository<Product>().AddAsync(product);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(product);
        //    }

        //    // GET: Products/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var product = await _context.Repository<Product>().FindByIdAsync(id);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(product);
        //    }

        //    // POST: Products/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,CreationDate,ImageThumbnailPath")] Product product)
        //    {
        //        if (id != product.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                await _context.Repository<Product>().UpdateAsync(product);
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if ( !await _context.Repository<Product>().ExistsAsync(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(product);
        //    }

        //    // GET: Products/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var product = await _context.Repository<Product>().FindByIdAsync(id);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(product);
        //    }

        //    // POST: Products/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var product = await _context.Repository<Product>().FindByIdAsync(id);
        //        await _context.Repository<Product>().RemoveAsync(product);
        //        return RedirectToAction(nameof(Index));
        //    }
    }
}
