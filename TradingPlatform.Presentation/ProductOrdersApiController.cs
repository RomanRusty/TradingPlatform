﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.Contracts.ProductOrder;

namespace TradingPlatform.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersApiController : DefaultApiController
    {
        // GET: api/ProductOrdersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOrderReadDto>>> GetProductOrders()
        {
            var productOrders = await ServiceManager.ProductOrderService.GetAllAsync();

            return Ok(productOrders);
        }

        // GET: api/ProductOrdersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOrderReadDto>> GetProductOrder(int id)
        {
            var productOrder = await ServiceManager.ProductOrderService.GetByIdAsync(id);

            return Ok(productOrder);
        }

        // PUT: api/ProductOrdersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductOrder(int id, ProductOrderCreateDto productOrderCreateDto)
        {
            await ServiceManager.ProductOrderService.UpdateAsync(id, productOrderCreateDto);

            return NoContent();
        }

        // POST: api/ProductOrdersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductOrderReadDto>> CreateProductOrder(ProductOrderCreateDto productOrderCreateDto)
        {
            var productOrderReadDto = await ServiceManager.ProductOrderService.CreateAsync(productOrderCreateDto);

            return Ok(productOrderReadDto);
        }

        // DELETE: api/ProductOrdersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOrder(int id)
        {
            await ServiceManager.ProductOrderService.DeleteAsync(id);

            return NoContent();
        }
    }
}
