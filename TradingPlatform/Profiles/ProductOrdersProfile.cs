using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Dtos;
namespace TradingPlatform.Profiles
{
    public class ProductOrdersProfile:Profile
    {
        public ProductOrdersProfile()
        {
            CreateMap<ProductOrder, ProductOrderReadDto>();
            CreateMap<ProductOrderCreateDto, ProductOrder>();
        }
    }
}
