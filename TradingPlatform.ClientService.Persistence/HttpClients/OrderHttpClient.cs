
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
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityExceptions;
using TradingPlatform.EntityExceptions.Order;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class OrderHttpClient:HttpClientBase,IOrderHttpClient
    {
        private readonly ILogger<OrderHttpClient> _logger;
        public OrderHttpClient(IOptions<AppConfiguration> config, HttpClient client, ILoggerFactory loggerFactory, ITokenManager tokenManager, IHttpContextAccessor contextAccessor) :
            base(config, client, tokenManager, contextAccessor)
        {
            _logger = loggerFactory is not null ? loggerFactory.CreateLogger<OrderHttpClient>() : throw new ArgumentNullException(nameof(loggerFactory));
            _apiName = "OrdersApi";
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            var response = await GetRequestAsync(_apiName);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<OrderReadDto>>(response);
        }

        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var response = await GetRequestAsync(_apiName + "/" + id);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            var orderDto = await DeserializeAsync<OrderReadDto>(response);

            if (orderDto == null)
            {
                throw new OrderNotFoundException("Order not found");
            }
            return orderDto;
        }
        public async Task UpdateAsync(int id, OrderCreateDto orderCreateDto)
        {
            if (id != orderCreateDto.Id)
            {
                throw new OrderNotFoundException("Order with such id does not exsist");
            }

            var jsonContent = JsonSerializer.Serialize(orderCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PutRequestAsync(_apiName + "/" + id, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                throw new BadRequestException("Request to database service failed");
            }
        }
        public async Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(orderCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PostRequestAsync(_apiName, data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<OrderReadDto>(response);
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
        public async Task<IEnumerable<OrderReadDto>> FindBySearchAsync(OrderSearchDto orderSearchDto)
        {
            var jsonContent = JsonSerializer.Serialize(orderSearchDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await PostRequestAsync(_apiName + "/by-filter", data);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Request failed {Route} Status code {StatusCode} Content {Content}", response.RequestMessage.RequestUri, response.StatusCode, await response.Content.ReadAsStringAsync());
                return default;
            }
            return await DeserializeAsync<IEnumerable<OrderReadDto>>(response);
        }
    }
}
