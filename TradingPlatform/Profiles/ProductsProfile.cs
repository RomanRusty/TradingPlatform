using AutoMapper;
using TradingPlatform.DataAccess;
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
