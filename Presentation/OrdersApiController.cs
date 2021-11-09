using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.Contracts.Order;

namespace TradingPlatform.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : DefaultApiController
    {
        // GET: api/OrdersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            var orders = await ServiceManager.OrderService.GetAllAsync();

            return Ok(orders);
        }

        // GET: api/OrdersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
        {
            var order = await ServiceManager.OrderService.GetByIdAsync(id);

            return order;
        }

        // PUT: api/OrdersApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderCreateDto orderCreateDto)
        {
            await ServiceManager.OrderService.UpdateAsync(id, orderCreateDto);

            return NoContent();
        }

        // POST: api/OrdersApi
        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var orderReadDto = await ServiceManager.OrderService.CreateAsync(orderCreateDto);

            return Ok(orderReadDto);
        }

        // DELETE: api/OrdersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await ServiceManager.OrderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
