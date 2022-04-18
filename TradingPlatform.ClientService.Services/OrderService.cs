using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.Entities;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Enums;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        UserManager<ApplicationUser> _userManager;
        public OrderService(IHttpClientManager client, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager) : base(client, contextAccessor)
        {
            _userManager = userManager;
        }
        public async Task<IEnumerable<OrderReadDto>> IndexAsync()
        {
            return await _client.OrderHttpClient.GetAllAsync();
        }

        public async Task<OrderReadDto> DetailsAsync(int id)
        {
            return await _client.OrderHttpClient.GetByIdAsync(id);
        }
        public async Task CreatePostAsync(OrderCreateDto orderCreateDto)
        {
            orderCreateDto.CreationDate = DateTime.Now.Date;
            orderCreateDto.CustumerId = (await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name)).Id;
            orderCreateDto.Status = OrderStatus.Selecting;
            await _client.OrderHttpClient.CreateAsync(orderCreateDto);
        }
        public async Task UpdateAsync(int id, OrderCreateDto orderCreateDto)
        {
            await _client.OrderHttpClient.UpdateAsync(id, orderCreateDto);
        }
        public async Task DeleteAsync(int id)
        {
            await _client.OrderHttpClient.DeleteAsync(id);
        }
    }
}
