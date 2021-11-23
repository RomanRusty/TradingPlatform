using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
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
