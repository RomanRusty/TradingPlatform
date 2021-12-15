using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Carts;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Services
{
    public class CartService : ServiceBase, ICartService
    {
        public CartService(IHttpClientManager client, IHttpContextAccessor contextAccessor) : base(client, contextAccessor)
        {
        }
        public async Task<CartViewModel> IndexAsync()
        {
            var orders= await _client.OrderHttpClient.FindBySearchAsync(new EntityContracts.Order.OrderSearchDto() { CustumerName = _contextAccessor.HttpContext.User.Identity.Name });
            return new CartViewModel() { Orders = orders };
        }
        public async Task AddProductToOrderAsync(ProductOrderCreateDto productOrder)
        {
            await _client.ProductOrderHttpClient.CreateAsync(productOrder);
        }
    }
}