using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Contracts;
using TradingPlatform.ClientService.Contracts.Products;
using TradingPlatform.EntityContracts.Category;
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
        Task DeleteAsync(int id);
    }
}