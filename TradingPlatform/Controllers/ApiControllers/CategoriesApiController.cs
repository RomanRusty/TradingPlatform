using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingPlatform.DataAccess;
using TradingPlatform.DataAccess.Repository;

namespace TradingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly IGenericUnitOfWork _context;
        public CategoriesApiController(IGenericUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/CategoriesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _context.Repository<Category>().GetAllAsync());
        }

        // GET: api/CategoriesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory(int id)
        {

            var category = await _context.Repository<Category>().FindByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // PUT: api/CategoriesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            try
            {
                await _context.Repository<Category>().UpdateAsync(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Repository<Category>().Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CategoriesApi
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _context.Repository<Category>().AddAsync(category);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/CategoriesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Repository<Category>().FindByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _context.Repository<Category>().RemoveAsync(category);
            return NoContent();
        }
    }
}
