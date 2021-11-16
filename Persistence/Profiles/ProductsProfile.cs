using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Contracts.Product;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
