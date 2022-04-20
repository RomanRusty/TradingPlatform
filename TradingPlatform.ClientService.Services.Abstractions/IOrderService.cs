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
        Task<OrderCreateDto> CreateGetAsync();
        Task CreatePostAsync(OrderCreateDto productCreateViewModel);
        Task<OrderCreateDto> EditGetAsync(int id);
        Task EditPostAsync(int id, OrderCreateDto productCreateDto);
        Task DeleteAsync(int id);
    }
}