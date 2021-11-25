using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ProductOrdersProfile : Profile
    {
        public ProductOrdersProfile()
        {
            CreateMap<ProductOrder, ProductOrderReadDto>()
                .ForMember(p => p.OrderId, opt => opt.MapFrom(p => p.Order != null ? p.Order.Id : default))
                .ForMember(p => p.ProductId, opt => opt.MapFrom(p => p.Product != null ? p.Product.Id : default));

            CreateMap<ProductOrderCreateDto, ProductOrder>();
        }
    }
}
