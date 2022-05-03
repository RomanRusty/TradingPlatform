using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.EntityContracts.Product;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Contracts.Modals
{
    public class AddItemToCartViewModel
    {
        public ProductReadDto Product { get; set; }
        public SelectList Orders { get; set; }
        public ProductOrderCreateDto ProductOrder { get; set; }
    }
}
