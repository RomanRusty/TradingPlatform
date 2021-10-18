using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using TradingPlatform.DataAccess;
using TradingPlatform.DataAccess.Repository;

namespace TradingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersApiController : ControllerBase
    {
        private readonly IGenericUnitOfWork _context;

        public ProductOrdersApiController(IGenericUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/ProductOrdersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOrder>>> GetProductOrders()
        {
            return Ok(await _context.Repository<ProductOrder>().GetAllAsync());
        }

        // GET: api/ProductOrdersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOrder>> GetProductOrder(int id)
        {
            var productOrder = await _context.Repository<ProductOrder>().FindByIdAsync(id);

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

            try
            {
                await _context.Repository<ProductOrder>().UpdateAsync(productOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Repository<ProductOrder>().Exists(id))
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
            await _context.Repository<ProductOrder>().AddAsync(productOrder);

            return CreatedAtAction("GetProductOrder", new { id = productOrder.Id }, productOrder);
        }

        // DELETE: api/ProductOrdersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOrder(int id)
        {
            var productOrder = await _context.Repository<ProductOrder>().FindByIdAsync(id);
            if (productOrder == null)
            {
                return NotFound();
            }

            await _context.Repository<ProductOrder>().RemoveAsync(productOrder);
            return NoContent();
        }
    }
}
