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
using TradingPlatform.EntityContracts.ProductOrder;
using TradingPlatform.EntityExceptions.ProductOrder;

namespace TradingPlatform.ClientService.Services
{
    public class ProductOrderService : ServiceBase, IProductOrderService
    {
        public ProductOrderService(IOptions<AppConfiguration> config, HttpClient client) : base(config, client)
        {
        }
        public async Task<IEnumerable<ProductOrderReadDto>> GetAllAsync()
        {
            var productOrdersJson = await _client.GetStreamAsync("api/CategoriesApi");
            var productOrdersDto = await JsonSerializer.DeserializeAsync<IEnumerable<ProductOrderReadDto>>(productOrdersJson);
            return productOrdersDto;
        }
        public async Task<ProductOrderReadDto> GetByIdAsync(int id)
        {
            var productOrderJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var productOrderDto = await JsonSerializer.DeserializeAsync<ProductOrderReadDto>(productOrderJson);

            if (productOrderDto == null)
            {
                throw new ProductOrderNotFoundException("ProductOrder not found");
            }
            return productOrderDto;
        }
        public async Task UpdateAsync(int id, ProductOrderCreateDto productOrderCreateDto)
        {
            if (id != productOrderCreateDto.Id)
            {
                throw new ProductOrderNotFoundException("ProductOrder with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(productOrderCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _client.PutAsync("api/CategoriesApi/" + id, data);

        }
        public async Task<ProductOrderReadDto> CreateAsync(ProductOrderCreateDto productOrderCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(productOrderCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var productOrderJson = await _client.PostAsync("api/CategoriesApi", data);

            var categoriesDto = await JsonSerializer.DeserializeAsync<ProductOrderReadDto>(await productOrderJson.Content.ReadAsStreamAsync());
            return categoriesDto;
        }
        public async Task DeleteAsync(int id)
        {
            var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var productOrderDto = await JsonSerializer.DeserializeAsync<ProductOrderReadDto>(categoriesJson);
            if (productOrderDto == null)
            {
                throw new ProductOrderNotFoundException("ProductOrder with such id does not exsists");
            }
        }
    }
}
