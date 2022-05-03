using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.ClientService.Domain.HttpInterfaces
{
    public interface ICategoryHttpClient
    {
        public Task<IEnumerable<CategoryReadDto>> GetAllAsync();
        public Task<CategoryReadDto> GetByIdAsync(int id);
        public Task UpdateAsync(int id, CategoryCreateDto categoryCreateDto);
        public Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<CategoryReadDto>> FindBySearchAsync(CategorySearchDto categorySearchDto);
    }
}
