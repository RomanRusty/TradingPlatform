using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Products;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Presentation
{

    public class ProductsController : ControllerBase
    {
        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await ServiceManager.ProductService.IndexAsync());
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await ServiceManager.ProductService.DetailsAsync(id));
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            return View(await ServiceManager.ProductService.CreateGetAsync());
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await ServiceManager.ProductService.CreatePostAsync(viewModel);
                return RedirectToAction(nameof(Index),"Home");
            }
            viewModel.Categories = (await ServiceManager.ProductService.CreateGetAsync()).Categories;
            return View(viewModel);
        }
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await ServiceManager.ProductService.EditGetAsync(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,CreationDate,ImageThumbnailPath")] ProductCreateDto product)
        {
            if (ModelState.IsValid)
            {
                await ServiceManager.ProductService.EditPostAsync(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await ServiceManager.ProductService.DeleteAsync(id);
            return View();
        }
    }
}
