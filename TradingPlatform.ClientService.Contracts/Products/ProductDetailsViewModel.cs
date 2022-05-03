using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Contracts.Products
{
    public class ProductDetailsViewModel
    {
        public ProductReadDto Product { get; set; }
        public SelectList AvailableOrdersSelectList { get; set; }
    }
}
