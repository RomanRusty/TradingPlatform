﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TradingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> IndexAsync(string sortOrder, string currentFilter, string searchString, string category, int page)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44338/")
            };

            var response = await client.GetAsync("api/CategoriesApi");
            Console.WriteLine(response);

            //int rowsOnPage = 5;
            //int itemsInRow = 3;
            //int itemsOnPage = rowsOnPage * itemsInRow;

            //ViewData["PriceSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //IEnumerable<ProductReadDto> products;
            //if (category == null)
            //{
            //    products =await ServiceManager.ProductService.GetAllAsync();
            //}
            //else
            //{
            //    products = _context.Repository<Product>().FindAll(item => item.Category.Name == category);
            //}
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    products = products.Where(item => item.Name.Contains(searchString));
            //}
            //products = sortOrder switch
            //{
            //    "price_desc" => products.OrderByDescending(s => s.Price),
            //    "date" => products.OrderBy(s => s.CreationDate),
            //    "date_desc" => products.OrderByDescending(s => s.CreationDate),
            //    _ => products.OrderBy(s => s.Price),
            //};
            //IEnumerable<Product> sortedProducts = products.Skip((page - 1) * itemsOnPage).Take(itemsOnPage).ToList();
            //List<List<Product>> jaggProducts = _context.Repository<Product>().ToJaggedArray(sortedProducts, itemsInRow);

            //ItemPaginationViewModel itemPaginationModel = new ItemPaginationViewModel(true, products.Count(), page, itemsOnPage, 5);
            //itemPaginationModel.CurrentSort = sortOrder;
            //itemPaginationModel.CurrentFilter = searchString;

            //SelectList orderSelectList = null;

            //if (User.Identity.IsAuthenticated)
            //{
            //    IEnumerable<Order> orders = _context.Repository<Order>().FindAll(t => t.Status == OrderStatus.Selecting && t.Custumer.UserName == User.Identity.Name);
            //    orderSelectList = new SelectList(orders, "Id", "Name");
            //}
            //return View(new IndexViewModel() {Products=new List<List<ProductReadDto>>(), AvailableOrdersSelectList = orderSelectList, ItemPagination = itemPaginationModel });
            return View();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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