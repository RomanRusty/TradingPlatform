using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingPlatform.Data;
using TradingPlatform.DataAccess;
using TradingPlatform.DataAccess.Repository;

namespace TradingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductOrdersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductOrdersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOrder>>> GetProductOrders()
        {
            return await _context.ProductOrders.ToListAsync();
        }

        // GET: api/ProductOrdersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOrder>> GetProductOrder(int id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);

            if (productOrder == null)
            {
                return NotFound();
            }

            return productOrder;
        }

        // PUT: api/ProductOrdersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOrder(int id, ProductOrder productOrder)
        {
            if (id != productOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(productOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOrderExists(id))
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

        // POST: api/ProductOrdersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductOrder>> PostProductOrder(ProductOrder productOrder)
        {
            _context.ProductOrders.Add(productOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductOrder", new { id = productOrder.Id }, productOrder);
        }

        // DELETE: api/ProductOrdersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOrder(int id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            _context.ProductOrders.Remove(productOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductOrderExists(int id)
        {
            return _context.ProductOrders.Any(e => e.Id == id);
        }
    }
}
