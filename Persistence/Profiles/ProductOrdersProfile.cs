using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Contracts.ProductOrder;

namespace TradingPlatform.Persistence.Profiles
{
    public class ProductOrdersProfile : Profile
    {
        public ProductOrdersProfile()
        {
            CreateMap<ProductOrder, ProductOrderReadDto>();
            CreateMap<ProductOrderCreateDto, ProductOrder>();
        }
    }
}
