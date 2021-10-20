using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Dtos;

namespace TradingPlatform.Profiles
{
    public class ProductsProfile:Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
