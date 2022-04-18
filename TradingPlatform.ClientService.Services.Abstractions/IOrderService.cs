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
        Task<IEnumerable<OrderReadDto>> IndexAsync();
        Task<OrderReadDto> DetailsAsync(int id);
        Task CreatePostAsync(OrderCreateDto orderCreateDto);
        Task UpdateAsync(int id, OrderCreateDto orderCreateDto);
        Task DeleteAsync(int id);
    }
}