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
        Task DeleteProductFromOrder(int productOrderId);
    }
}
