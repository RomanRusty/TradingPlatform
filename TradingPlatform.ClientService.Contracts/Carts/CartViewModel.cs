using System.Collections.Generic;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Contracts.Carts
{
    public class CartViewModel
    {
        public IEnumerable<OrderReadDto> Orders { get; set; }
    }
}
