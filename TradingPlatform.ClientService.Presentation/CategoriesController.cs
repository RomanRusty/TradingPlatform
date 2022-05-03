using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.ClientService.Presentation
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.IndexAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _categoryService.DetailsAsync(id));
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CategoryCreateDto categoryCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreatePostAsync(categoryCreateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryCreateDto);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _categoryService.EditGetAsync(id));
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] CategoryCreateDto categoryCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.EditPostAsync(id, categoryCreateDto);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryCreateDto);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.DetailsAsync(id);

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
