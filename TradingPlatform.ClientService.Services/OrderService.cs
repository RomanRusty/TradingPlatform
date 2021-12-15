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
        public async Task CreatePostAsync(OrderCreateDto orderCreateDto)
        {
            orderCreateDto.CreationDate = DateTime.Now.Date;
            orderCreateDto.CustumerId = (await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name)).Id;
            orderCreateDto.Status = OrderStatus.Selecting;
            await _client.OrderHttpClient.CreateAsync(orderCreateDto);
        }
    }
}
