using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Contracts.Order;

namespace TradingPlatform.Persistence.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
