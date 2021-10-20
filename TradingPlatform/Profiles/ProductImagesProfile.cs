using AutoMapper;
using TradingPlatform.DataAccess;
using TradingPlatform.Dtos;
namespace TradingPlatform.Profiles
{
    public class ProductImagesProfile:Profile
    {
        public ProductImagesProfile()
        {
            CreateMap<ProductImage, ProductImageReadDto>();
            CreateMap<ProductImageCreateDto, ProductImage>();
        }
    }
}
