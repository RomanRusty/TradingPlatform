using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : DefaultApiController
    {
        // GET: api/CategoriesApi
        [HttpGet]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetCategories()
        {
            var categories = await ServiceManager.CategoryService.GetAllAsync();

            return Ok(categories);
        }

        // GET: api/CategoriesApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetCategory(int id)
        {
            var category = await ServiceManager.CategoryService.GetByIdAsync(id);

            return Ok(category);
        }

        // PUT: api/CategoriesApi/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreateDto categoryCreateDto)
        {
            await ServiceManager.CategoryService.UpdateAsync(id, categoryCreateDto);

            return Ok();
        }

        // POST: api/CategoriesApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryReadDto>> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var categoryReadDto = await ServiceManager.CategoryService.CreateAsync(categoryCreateDto);

            return Ok(categoryReadDto);
        }

        // DELETE: api/CategoriesApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CategoryReadDto), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await ServiceManager.CategoryService.DeleteAsync(id);

            return NoContent();
        }

    }
}
