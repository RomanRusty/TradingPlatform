using System.Collections.Generic;
using TradingPlatform.ClientService.Contracts.Modals;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Contracts.Home
{
    public class IndexViewModel
    {
        public List<List<ProductReadDto>> Products { get; set; }
        public ItemPaginationViewModel ItemPagination { get; set; }
    }
}
