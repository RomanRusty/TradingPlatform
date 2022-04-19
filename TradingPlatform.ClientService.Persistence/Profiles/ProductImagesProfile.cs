using AutoMapper;
using TradingPlatform.EntityContracts.ProductImage;

namespace TradingPlatform.ClientService.Persistence.Profiles
{
    public class ProductImagesProfile : Profile
    {
        public ProductImagesProfile()
        {
            CreateMap<ProductImageReadDto, ProductImageCreateDto>().MaxDepth(2);
            CreateMap<ProductImageCreateDto, ProductImageReadDto>().MaxDepth(2);

            CreateMap<ProductImageReadDto, ProductImageCreateDto>().MaxDepth(2);
            CreateMap<ProductImageCreateDto, ProductImageReadDto>().MaxDepth(2);
        }
    }
}
