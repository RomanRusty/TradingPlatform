using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.Contracts.ProductOrder;

namespace TradingPlatform.Services.Abstractions
{
    public interface IProductOrderService
    {
        Task<IEnumerable<ProductOrderReadDto>> GetAllAsync();
        Task<ProductOrderReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, ProductOrderCreateDto productReadDto);
        Task<ProductOrderReadDto> CreateAsync(ProductOrderCreateDto productCreateDto);
        Task DeleteAsync(int id);
    }
}
