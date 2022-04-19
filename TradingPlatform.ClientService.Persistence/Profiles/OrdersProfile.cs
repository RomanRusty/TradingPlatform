using AutoMapper;
using TradingPlatform.EntityContracts.Order;

namespace TradingPlatform.ClientService.Persistence.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrderReadDto, OrderCreateDto>().MaxDepth(2);
            CreateMap<OrderCreateDto, OrderReadDto>().MaxDepth(2);
        }
    }
}
