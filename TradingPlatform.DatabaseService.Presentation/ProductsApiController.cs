using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Services.Abstractions;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.DatabaseService.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsApiController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            
        }

        // GET: api/ProductsApi

        [HttpGet]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
            IEnumerable<ProductReadDto> products = await _productService.GetAllAsync();

            return Ok(products);
        }

        // GET: api/ProductsApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            ProductReadDto product = await _productService.GetByIdAsync(id);

            return Ok(product);
        }

        // PUT: api/ProductsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize (Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateDto productCreateDto)
        {
            await _productService.UpdateAsync(id, productCreateDto);
            return Ok();
        }

        // POST: api/ProductsApi
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status200OK)]
        [Authorize(Roles = UserRoles.Seller)]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = await _productService.CreateAsync(productCreateDto);

            return Ok(product);
        }

        // DELETE: api/ProductsApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProductReadDto), StatusCodes.Status204NoContent)]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Seller)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }
        [HttpPost("by-filter")]
        [ProducesResponseType(typeof(IEnumerable<ProductReadDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetBySearchFilterAsync(ProductSearchDto filter)
        {
            var products = await _productService.FindBySearchAsync(filter);

            return Ok( products);
        }
    }
}
