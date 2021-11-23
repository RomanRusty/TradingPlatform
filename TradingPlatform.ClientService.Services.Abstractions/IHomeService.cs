using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Home;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IHomeService
    {
        Task<IndexViewModel> IndexAsync();
        //Task<CategoryReadDto> GetByIdAsync(int id);
        //Task UpdateAsync(int id, CategoryCreateDto categoryReadDto);
        //Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryCreateDto);
        //Task DeleteAsync(int id);
    }
}
