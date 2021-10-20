using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Dtos;
namespace TradingPlatform.Profiles
{
    public class CategoriesProfile :Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
