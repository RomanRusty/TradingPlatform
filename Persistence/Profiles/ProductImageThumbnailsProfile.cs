using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Contracts.ProductImageThumbnail;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
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
