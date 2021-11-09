using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.Contracts.Product;

namespace TradingPlatform.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : DefaultApiController
    {
        // GET: api/ProductsApi

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
            IEnumerable<ProductReadDto> products = await ServiceManager.ProductService.GetAllAsync();

            return Ok(products);
        }

        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            ProductReadDto product = await ServiceManager.ProductService.GetByIdAsync(id);

            return Ok(product);
        }

        // PUT: api/ProductsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateDto productCreateDto)
        {
            await ServiceManager.ProductService.UpdateAsync(id, productCreateDto);

            return Ok();
        }

        // POST: api/ProductsApi
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var productReadDto = await ServiceManager.ProductService.CreateAsync(productCreateDto);

            return Ok(productReadDto);
        }

        // DELETE: api/ProductsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await ServiceManager.ProductService.DeleteAsync(id);

            return Ok();
        }
    }
}
