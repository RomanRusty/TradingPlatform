using Microsoft.AspNetCore.Mvc;

namespace TradingPlatform.Controllers
{
    public class CartsController : Controller
    {
        //private readonly IGenericUnitOfWork _context;
        //public CartsController(IGenericUnitOfWork context)
        //{
        //    _context = context;
        //}

        //public IActionResult Index()
        //{
        //    //List<Order> orders = new(_context.Repository<Order>().GetWithInclude(item => item.Custumer.UserName == User.Identity.Name, item => item.Custumer, item => item.ProductOrders, item => item.ProductOrders));
        //    List<Order> orders = new(_context.Repository<Order>().FindAll(item => item.Custumer.UserName == User.Identity.Name));
        //    return View(new CartModel() { Orders = orders });
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddProductToOrder(ProductOrder productOrder)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //productOrder.Product = _context.Repository<Product>().FindById(productOrder.ProductIdSelect);
        //        //productOrder.Order = _context.Repository<Order>().FindById(productOrder.OrderIdSelect);
        //        await _context.Repository<ProductOrder>().AddAsync(productOrder);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
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


