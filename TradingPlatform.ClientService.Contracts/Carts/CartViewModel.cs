using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Contracts.Carts
{
    public class CartViewModel
    {
        public IEnumerable<OrderReadDto> Orders { get; set; }
    }
}
