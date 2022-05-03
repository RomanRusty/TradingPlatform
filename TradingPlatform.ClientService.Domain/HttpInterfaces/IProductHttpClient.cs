using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Domain.HttpInterfaces
{
    public interface IProductHttpClient
    {
        public Task<IEnumerable<ProductReadDto>> GetAllAsync();
        public Task<ProductReadDto> GetByIdAsync(int id);
        public Task UpdateAsync(int id, ProductCreateDto productCreateDto);
        public Task<ProductReadDto> CreateAsync(ProductCreateDto productCreateDto);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<ProductReadDto>> FindBySearchAsync(ProductSearchDto productSearchDto);
    }
}
