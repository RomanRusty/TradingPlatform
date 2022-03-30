using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesApiController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        // GET: api/CategoriesApi
        [HttpGet]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        // GET: api/CategoriesApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(category);
        }

        // PUT: api/CategoriesApi/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreateDto categoryCreateDto)
        {
            await _categoryService.UpdateAsync(id, categoryCreateDto);

            return Ok();
        }

        // POST: api/CategoriesApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<CategoryReadDto>> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var categoryReadDto = await _categoryService.CreateAsync(categoryCreateDto);

            return Ok(categoryReadDto);
        }

        // DELETE: api/CategoriesApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status204NoContent)]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);

            return NoContent();
        }
        [HttpPost("by-filter")]
        [ProducesResponseType(typeof(IEnumerable<CategoryReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetBySearchFilterAsync([FromBody] CategorySearchDto filter)
        {
            var products = await _categoryService.FindBySearchAsync(filter);

            return Ok(products);
        }
    }
}
