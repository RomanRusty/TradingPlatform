using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.ProductImage;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ProductImagesProfile : Profile
    {
        public ProductImagesProfile()
        {
            CreateMap<ProductImage, ProductImageReadDto>().MaxDepth(2);
            CreateMap<ProductImageCreateDto, ProductImage>().MaxDepth(2);

            CreateMap<ProductImageThumbnail, ProductImageReadDto>().MaxDepth(2);
            CreateMap<ProductImageCreateDto, ProductImageThumbnail>().MaxDepth(2);
        }
    }
}
