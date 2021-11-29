
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            _apiName = "ProductsApi";
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var response = await _client.GetAsync(_apiName);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DesserializeAsync<IEnumerable<ProductReadDto>>(response);
        }

        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync(_apiName + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var productDto = await DesserializeAsync<ProductReadDto>(response);

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
            var response = await _client.PutAsync(_apiName + id, data);
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
            var response = await _client.PostAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DesserializeAsync<ProductReadDto>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _client.GetAsync(_apiName + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
            var productDto = await DesserializeAsync<ProductReadDto>(response);
            if (productDto == null)
            {
                throw new ProductNotFoundException("Product with such id does not exsists");
            }
        }
        public async Task<IEnumerable<ProductReadDto>> FindBySearchAsync(ProductSearchDto productSearchDto)
        {
            var jsonContent = JsonSerializer.Serialize(productSearchDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DesserializeAsync<IEnumerable<ProductReadDto>>(response);
        }
    }
}
