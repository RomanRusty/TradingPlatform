using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IHomeService
    {
        Task<IndexViewModel> IndexAsync(string sortOrder, string currentFilter, string searchString, string category, int page);
        //Task<CategoryReadDto> GetByIdAsync(int id);
        //Task UpdateAsync(int id, CategoryCreateDto categoryReadDto);
        //Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        //Task DeleteAsync(int id);
    }
}
