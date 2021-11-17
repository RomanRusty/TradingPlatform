using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetAllAsync();
        Task<CategoryReadDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, CategoryCreateDto categoryReadDto);
        Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task DeleteAsync(int id);
    }
}
