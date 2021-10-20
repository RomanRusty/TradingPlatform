using AutoMapper;
using TradingPlatform.DataAccess;
using TradingPlatform.Dtos.Order;
namespace TradingPlatform.Profiles
{
    public class OrdersProfile:Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
