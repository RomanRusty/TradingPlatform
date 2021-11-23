
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Product;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class ProductHttpClient:HttpClientBase,IProductHttpClient
    {
        private readonly ILogger<ProductHttpClient> _logger;
        public ProductHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILogger<ProductHttpClient> logger) : base(config, client)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("ProductsApi");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductReadDto>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("ProductsApi" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var productDto = await JsonSerializer.DeserializeAsync<ProductReadDto>(await response.Content.ReadAsStreamAsync());

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
            var response = await _client.PutAsync("ProductsApi" + id, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(productCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("ProductsApi", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await JsonSerializer.DeserializeAsync<ProductReadDto>(await response.Content.ReadAsStreamAsync());
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _client.GetAsync("ProductsApi" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
            var productDto = await JsonSerializer.DeserializeAsync<ProductReadDto>(await response.Content.ReadAsStreamAsync());
            if (productDto == null)
            {
                throw new ProductNotFoundException("Product with such id does not exsists");
            }
        }
    }
}
