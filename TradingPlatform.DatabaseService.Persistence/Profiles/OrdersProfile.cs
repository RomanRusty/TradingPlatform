using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderReadDto>()
                .ForMember(p => p.CustumerId, opt => opt.MapFrom(p => p.Custumer != null ? p.Custumer.Id : default)).MaxDepth(2);
            CreateMap<OrderCreateDto, Order>().MaxDepth(2);
        }
    }
}
