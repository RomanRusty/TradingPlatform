using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Contracts.ProductOrder;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersApiController : DefaultApiController
    {
        // GET: api/ProductOrdersApi
        [HttpGet]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductOrderReadDto>>> GetProductOrders()
        {
            var productOrders = await ServiceManager.ProductOrderService.GetAllAsync();

            return Ok(productOrders);
        }

        // GET: api/ProductOrdersApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductOrderReadDto>> GetProductOrder(int id)
        {
            var productOrder = await ServiceManager.ProductOrderService.GetByIdAsync(id);

            return Ok(productOrder);
        }

        // PUT: api/ProductOrdersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProductOrder(int id, ProductOrderCreateDto productOrderCreateDto)
        {
            await ServiceManager.ProductOrderService.UpdateAsync(id, productOrderCreateDto);

            return NoContent();
        }

        // POST: api/ProductOrdersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductOrderReadDto>> CreateProductOrder(ProductOrderCreateDto productOrderCreateDto)
        {
            var productOrderReadDto = await ServiceManager.ProductOrderService.CreateAsync(productOrderCreateDto);

            return Ok(productOrderReadDto);
        }

        // DELETE: api/ProductOrdersApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductOrderReadDto), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProductOrder(int id)
        {
            await ServiceManager.ProductOrderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
