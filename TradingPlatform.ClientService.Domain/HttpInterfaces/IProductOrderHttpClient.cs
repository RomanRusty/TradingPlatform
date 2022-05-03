using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Domain.HttpInterfaces
{
    public interface IProductOrderHttpClient
    {
        public Task<IEnumerable<ProductOrderReadDto>> GetAllAsync();
        public Task<ProductOrderReadDto> GetByIdAsync(int id);
        public Task UpdateAsync(int id, ProductOrderCreateDto productOrderCreateDto);
        public Task<ProductOrderReadDto> CreateAsync(ProductOrderCreateDto productOrderCreateDto);
        public Task DeleteAsync(int id);
    }
}
