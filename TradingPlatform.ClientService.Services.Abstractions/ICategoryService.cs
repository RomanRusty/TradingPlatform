using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> IndexAsync();
        Task<CategoryReadDto> DetailsAsync(int id);
        Task CreatePostAsync(CategoryCreateDto categoryCreateDto);
        Task<CategoryCreateDto> EditGetAsync(int id);
        Task EditPostAsync(int id, CategoryCreateDto categoryCreateDto);

        Task DeleteAsync(int id);
    }
}
