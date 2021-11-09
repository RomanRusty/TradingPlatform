using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Contracts.ProductImage;

namespace TradingPlatform.Persistence.Profiles
{
    public class ProductImagesProfile : Profile
    {
        public ProductImagesProfile()
        {
            CreateMap<ProductImage, ProductImageReadDto>();
            CreateMap<ProductImageCreateDto, ProductImage>();
        }
    }
}
