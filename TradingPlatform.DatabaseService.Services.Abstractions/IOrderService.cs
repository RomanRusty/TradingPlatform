using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.DatabaseService.Services.Abstractions
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        Task<OrderReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, OrderCreateDto productReadDto);
        Task<OrderReadDto> CreateAsync(OrderCreateDto productCreateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<OrderReadDto>> FindBySearchAsync(OrderSearchDto orderSearchDto);
    }
}
