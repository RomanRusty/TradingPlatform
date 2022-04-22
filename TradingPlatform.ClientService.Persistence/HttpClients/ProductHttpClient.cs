
using Microsoft.AspNetCore.Http;
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
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Product;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class ProductHttpClient : HttpClientBase, IProductHttpClient
    {
        private readonly ILogger<ProductHttpClient> _logger;
        public ProductHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILoggerFactory loggerFactory, ITokenManager tokenManager, IHttpContextAccessor contextAccessor) :
            base(config, client, tokenManager, contextAccessor)
        {
            _logger = loggerFactory is not null ? loggerFactory.CreateLogger<ProductHttpClient>() : throw new ArgumentNullException(nameof(loggerFactory));
            _apiName = "ProductsApi";
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var response = await GetRequestAsync(_apiName);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<ProductReadDto>>(response);
        }

        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var response = await GetRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var productDto = await DeserializeAsync<ProductReadDto>(response);
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
            var response = await PutRequestAsync(_apiName + "/" + id, data);
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
            var response = await PostRequestAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<ProductReadDto>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var response = await DeleteRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<IEnumerable<ProductReadDto>> FindBySearchAsync(ProductSearchDto productSearchDto)
        {
            var jsonContent = JsonSerializer.Serialize(productSearchDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PostRequestAsync(_apiName + "/by-filter", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<ProductReadDto>>(response);
        }
    }
}
