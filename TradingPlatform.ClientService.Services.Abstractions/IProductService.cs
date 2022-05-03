using System.Collections.Generic;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts.Products;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> IndexAsync();
        Task<ProductDetailsViewModel> DetailsAsync(int id);
        Task<ProductCreateViewModel> CreateGetAsync();
        Task CreatePostAsync(ProductCreateViewModel productCreateViewModel);
        Task<ProductCreateDto> EditGetAsync(int id);
        Task EditPostAsync(int id, ProductCreateDto productCreateDto);
        Task<ProductReadDto> DeleteGetAsync(int id);
        Task DeletePostAsync(int id);
    }
}