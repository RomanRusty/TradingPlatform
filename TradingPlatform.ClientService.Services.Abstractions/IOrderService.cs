using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IOrderService
    {
        Task CreatePostAsync(OrderCreateDto orderCreateDto);
    }
}
