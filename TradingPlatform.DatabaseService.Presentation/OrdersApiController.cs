using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersApiController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        // GET: api/OrdersApi
        [HttpGet]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetOrders()
        {
            var orders = await _orderService.GetAllAsync();
            
            return Ok(orders);
        }

        // GET: api/OrdersApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> GetOrder(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            return order;
        }

        // PUT: api/OrdersApi/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Custumer)]
        public async Task<IActionResult> UpdateOrder(int id, OrderCreateDto orderCreateDto)
        {
            await _orderService.UpdateAsync(id, orderCreateDto);

            return Ok();
        }

        // POST: api/OrdersApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Custumer)]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var order = await _orderService.CreateAsync(orderCreateDto);

            return Ok(order);
        }

        // DELETE: api/OrdersApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status204NoContent)]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Custumer)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost("by-filter")]
        [ProducesResponseType(typeof(IEnumerable<OrderReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetBySearchFilterAsync( OrderSearchDto filter)
        {
            var orders = await _orderService.FindBySearchAsync(filter);

            return Ok(orders);
        }
    }
}
