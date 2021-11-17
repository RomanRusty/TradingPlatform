using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.ProductImage;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
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
