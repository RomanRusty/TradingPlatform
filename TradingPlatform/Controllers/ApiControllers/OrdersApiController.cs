using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Domain.Repository;

namespace TradingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly IGenericUnitOfWork _context;

        public OrdersApiController(IGenericUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/OrdersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _context.Repository<Order>().GetAllAsync());
        }

        // GET: api/OrdersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Repository<Order>().FindByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/OrdersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }


            try
            {
                await _context.Repository<Order>().UpdateAsync(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Repository<Order>().Exists(id))
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

        // POST: api/OrdersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _context.Repository<Order>().AddAsync(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/OrdersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Repository<Order>().FindByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            await _context.Repository<Order>().RemoveAsync(order);
            return NoContent();
        }
    }
}
