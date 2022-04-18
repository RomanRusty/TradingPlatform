using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.EntityContracts.ProductOrder;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.ProductOrder;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class ProductOrderHttpClient:HttpClientBase,IProductOrderHttpClient
    {
        private readonly ILogger<ProductOrderHttpClient> _logger;
        public ProductOrderHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILoggerFactory loggerFactory, ITokenManager tokenManager, IHttpContextAccessor contextAccessor) :
            base(config, client, tokenManager, contextAccessor)
        {
            _logger = loggerFactory is not null ? loggerFactory.CreateLogger<ProductOrderHttpClient>() : throw new ArgumentNullException(nameof(loggerFactory));
            _apiName = "ProductOrdersApi";
        }

        public async Task<IEnumerable<ProductOrderReadDto>> GetAllAsync()
        {
            var response = await GetRequestAsync(_apiName);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<ProductOrderReadDto>>(response);
        }

        public async Task<ProductOrderReadDto> GetByIdAsync(int id)
        {
            var response = await GetRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var productOrderDto =await DeserializeAsync<ProductOrderReadDto>(response);

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
            var response = await PutRequestAsync(_apiName + "/" + id, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<ProductOrderReadDto> CreateAsync(ProductOrderCreateDto productOrderCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(productOrderCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PostRequestAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<ProductOrderReadDto>(response);
        }
        public async Task DeleteAsync(int id)
        {
            var response = await DeleteRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
            var productOrderDto = DeserializeAsync<ProductOrderReadDto>(response);
            if (productOrderDto == null)
            {
                throw new ProductOrderNotFoundException("ProductOrder with such id does not exsists");
            }
        }
    }
}
