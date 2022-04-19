using AutoMapper;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.ClientService.Persistence.Profiles
{
    public class ProductOrdersProfile : Profile
    {
        public ProductOrdersProfile()
        {
            CreateMap<ProductOrderReadDto, ProductOrderCreateDto>().MaxDepth(2);

            CreateMap<ProductOrderCreateDto, ProductOrderReadDto>().MaxDepth(2);
        }
    }
}
