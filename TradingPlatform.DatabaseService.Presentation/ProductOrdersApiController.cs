using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersApiController : ControllerBase
    {
        private readonly IProductOrderService _productOrderService;

        public ProductOrdersApiController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService ?? throw new ArgumentNullException(nameof(productOrderService));
        }

        // GET: api/ProductOrdersApi
        [HttpGet]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductOrderReadDto>>> GetProductOrders()
        {
            var productOrders = await _productOrderService.GetAllAsync();

            return Ok(productOrders);
        }

        // GET: api/ProductOrdersApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<ProductOrderReadDto>> GetProductOrder(int id)
        {
            var productOrder = await _productOrderService.GetByIdAsync(id);

            return Ok(productOrder);
        }

        // PUT: api/ProductOrdersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateProductOrder(int id, ProductOrderCreateDto productOrderCreateDto)
        {
            await _productOrderService.UpdateAsync(id, productOrderCreateDto);

            return Ok();
        }

        // POST: api/ProductOrdersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Custumer)]
        public async Task<ActionResult<ProductOrderReadDto>> CreateProductOrder(ProductOrderCreateDto productOrderCreateDto)
        {
            var productOrder = await _productOrderService.CreateAsync(productOrderCreateDto);

            return Ok(productOrder);
        }

        // DELETE: api/ProductOrdersApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status204NoContent)]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Custumer)]
        public async Task<IActionResult> DeleteProductOrder(int id)
        {
            await _productOrderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
