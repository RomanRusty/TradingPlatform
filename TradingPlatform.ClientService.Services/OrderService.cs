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
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityExceptions.Order;

namespace TradingPlatform.ClientService.Services
{
    public class OrderService :ServiceBase, IOrderService
    {
        public OrderService(IOptions<AppConfiguration> config, HttpClient client) : base(config, client)
        {
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            var ordersJson = await _client.GetStreamAsync("api/CategoriesApi");
            var ordersDto = await JsonSerializer.DeserializeAsync<IEnumerable<OrderReadDto>>(ordersJson);
            return ordersDto;
        }
        public async Task<OrderReadDto> GetByIdAsync(int id)
        {
            var orderJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var orderDto = await JsonSerializer.DeserializeAsync<OrderReadDto>(orderJson);

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
            await _client.PutAsync("api/CategoriesApi/" + id, data);

        }
        public async Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto)
        {
            var jsonContent = JsonSerializer.Serialize(orderCreateDto);
            var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var orderJson = await _client.PostAsync("api/CategoriesApi", data);

            var categoriesDto = await JsonSerializer.DeserializeAsync<OrderReadDto>(await orderJson.Content.ReadAsStreamAsync());
            return categoriesDto;
        }
        public async Task DeleteAsync(int id)
        {
            var categoriesJson = await _client.GetStreamAsync("api/CategoriesApi/" + id);
            var orderDto = await JsonSerializer.DeserializeAsync<OrderReadDto>(categoriesJson);
            if (orderDto == null)
            {
                throw new OrderNotFoundException("Order with such id does not exsists");
            }
        }
    }
}
