using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TradingPlatform.ClientService.Contracts.Carts;
using TradingPlatform.ClientService.Contracts.Modals;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Services.Abstractions;
using TradingPlatform.EntityContracts.Order;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Services
{
    public class CartService : ServiceBase, ICartService
    {
        public CartService(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper) : base(client, contextAccessor, mapper)
        {
        }

        public async Task<CartViewModel> IndexAsync()
        {
            var orders = await _client.OrderHttpClient.FindBySearchAsync(new OrderSearchDto() { CustumerName = _contextAccessor.HttpContext.User.Identity.Name });
            return new CartViewModel() { Orders = orders };
        }
        public async Task AddProductToOrderAsync(ProductOrderCreateDto productOrder)
        {
            await _client.ProductOrderHttpClient.CreateAsync(productOrder);
        }

        public async Task<AddItemToCartViewModel> AddProductToOrderAsync(int productId)
        {
            SelectList orderSelectList = null;
            IEnumerable<OrderReadDto> orders = await _client.OrderHttpClient.FindBySearchAsync(new OrderSearchDto()
            {
                Status = EntityContracts.Enums.OrderStatus.Selecting,
                CustumerName = _contextAccessor.HttpContext.User.Identity.Name
            });
            if (orders is not null)
            {
                orderSelectList = new SelectList(orders, "Id", "Name");
            }
            return new AddItemToCartViewModel()
            {
                Orders = orderSelectList,
                Product = await _client.ProductHttpClient.GetByIdAsync(productId)
            };
        }

        public async Task DeleteProductFromOrder(int productOrderId)
        {
            await _client.ProductOrderHttpClient.DeleteAsync(productOrderId);
        }
    }
}