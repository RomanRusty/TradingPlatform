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
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, OrderCreateDto productReadDto);
        Task<OrderReadDto> CreateAsync(OrderCreateDto productCreateDto);
        Task DeleteAsync(int id);
    }
}
