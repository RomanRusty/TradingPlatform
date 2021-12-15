using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : DefaultApiController
    {
        // GET: api/ProductsApi

        [HttpGet]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
            IEnumerable<ProductReadDto> products = await ServiceManager.ProductService.GetAllAsync();

            return Ok(products);
        }

        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            ProductReadDto product = await ServiceManager.ProductService.GetByIdAsync(id);

            return Ok(product);
        }

        // PUT: api/ProductsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize (Roles ="Admin,Seller")]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateDto productCreateDto)
        {
            await ServiceManager.ProductService.UpdateAsync(id, productCreateDto);
            return Ok();
        }

        // POST: api/ProductsApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = await ServiceManager.ProductService.CreateAsync(productCreateDto);

            return Ok(product);
        }

        // DELETE: api/ProductsApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await ServiceManager.ProductService.DeleteAsync(id);

            return NoContent();
        }
        [HttpPost("by-filter")]
        [ProducesResponseType(typeof(IEnumerable<ProductReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetBySearchFilterAsync(ProductSearchDto filter)
        {
            var products = await ServiceManager.ProductService.FindBySearchAsync(filter);

            return Ok( products);
        }
    }
}
