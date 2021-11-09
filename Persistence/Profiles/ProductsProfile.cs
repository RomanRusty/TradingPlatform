using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Contracts.Product;

namespace TradingPlatform.Persistence.Profiles
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
