using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.Product;

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
