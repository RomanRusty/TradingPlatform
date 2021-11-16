using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.DatabaseService.Contracts.Category;

namespace TradingPlatform.DatabaseService.Services.Abstractions
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
