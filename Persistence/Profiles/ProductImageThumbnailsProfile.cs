using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Contracts.ProductImageThumbnail;

namespace TradingPlatform.Persistence.Profiles
{
    public class ProductImageThumbnailsProfile : Profile
    {
        public ProductImageThumbnailsProfile()
        {
            CreateMap<ProductImageThumbnail, ProductImageThumbnailReadDto>();
            CreateMap<ProductImageThumbnailCreateDto, ProductImageThumbnail>();
        }
    }
}
