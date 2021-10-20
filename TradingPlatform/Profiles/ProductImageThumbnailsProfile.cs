using AutoMapper;
using TradingPlatform.Domain.Entities;
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
