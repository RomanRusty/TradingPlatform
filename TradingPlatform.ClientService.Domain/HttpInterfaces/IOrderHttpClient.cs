using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Domain.HttpInterfaces
{
    public interface IOrderHttpClient
    {
        public Task<IEnumerable<OrderReadDto>> GetAllAsync();
        public Task<OrderReadDto> GetByIdAsync(int id);
        public Task UpdateAsync(int id, OrderCreateDto orderCreateDto);
        public Task<OrderReadDto> CreateAsync(OrderCreateDto orderCreateDto);
        public Task DeleteAsync(int id);
    }
}
