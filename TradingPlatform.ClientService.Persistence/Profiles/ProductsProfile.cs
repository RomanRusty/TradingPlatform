using AutoMapper;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.ClientService.Persistence.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductReadDto, ProductCreateDto>().MaxDepth(2);

            CreateMap<ProductCreateDto, ProductReadDto>().MaxDepth(2);
        }
    }
}
