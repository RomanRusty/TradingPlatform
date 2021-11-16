using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.DatabaseService.Contracts.ProductOrder;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
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
