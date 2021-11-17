using AutoMapper;
using ExampleWebApplication.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityExceptions.Product;

namespace TradingPlatform.ClientService.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IOptions<AppConfiguration> config, HttpClient client) : base(config, client)
        {
        }
        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var productsJson = await _client.GetStreamAsync("api/CategoriesApi");
            var productsDto = await JsonSerializer.DeserializeAsync<IEnumerable<ProductReadDto>>(productsJson);
            return productsDto;
        }
        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var productJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var productDto = await JsonSerializer.DeserializeAsync<ProductReadDto>(productJson);

            if (productDto == null)
            {
                throw new ProductNotFoundException("Product not found");
            }
            return productDto;
        }
        public async Task UpdateAsync(int id, ProductCreateDto productCreateDto)
        {
            if (id != productCreateDto.Id)
            {
                throw new ProductNotFoundException("Product with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(productCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _client.PutAsync("api/CategoriesApi/" + id, data);

        }
        public async Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(productCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var productJson = await _client.PostAsync("api/CategoriesApi", data);

            var categoriesDto = await JsonSerializer.DeserializeAsync<ProductReadDto>(await productJson.Content.ReadAsStreamAsync());
            return categoriesDto;
        }
        public async Task DeleteAsync(int id)
        {
            var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var productDto = await JsonSerializer.DeserializeAsync<ProductReadDto>(categoriesJson);
            if (productDto == null)
            {
                throw new ProductNotFoundException("Product with such id does not exsists");
            }
        }
    }
}
