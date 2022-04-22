using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Products;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Presentation
{

    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        // GET: Products

        public async Task<IActionResult> Index()
        {
            return View(await _productService.IndexAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _productService.DetailsAsync(id));
        }

        // GET: Products/Create
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> Create()
        {
            return View(await _productService.CreateGetAsync());
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreatePostAsync(viewModel);
                return RedirectToAction(nameof(Index),"Home");
            }
            viewModel.Categories = (await _productService.CreateGetAsync()).Categories;
            return View(viewModel);
        }
        // GET: Products/Edit/5
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _productService.EditGetAsync(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,CreationDate,ImageThumbnailPath")] ProductCreateDto product)
        {
            if (ModelState.IsValid)
            {
                await _productService.EditPostAsync(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.DeleteGetAsync(id);

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeletePostAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
