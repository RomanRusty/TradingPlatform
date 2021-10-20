using AutoMapper;
using TradingPlatform.DataAccess;
using TradingPlatform.Dtos;
namespace TradingPlatform.Profiles
{
    public class ProductImageThumbnailsProfile:Profile
    {
        public ProductImageThumbnailsProfile()
        {
            CreateMap<ProductImageThumbnail, ProductImageThumbnailReadDto>();
            CreateMap<ProductImageThumbnailCreateDto, ProductImageThumbnail>();
        }
    }
}
