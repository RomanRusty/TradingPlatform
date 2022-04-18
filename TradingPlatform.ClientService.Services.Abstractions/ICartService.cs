using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Carts;
using TradingPlatform.ClientService.Contracts.Modals;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface ICartService
    {
        Task<CartViewModel> IndexAsync();
        Task AddProductToOrderAsync(ProductOrderCreateDto productOrder);
        Task<AddItemToCartViewModel> AddProductToOrderAsync(int productId);
    }
}
