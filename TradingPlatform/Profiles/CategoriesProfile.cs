using AutoMapper;
using TradingPlatform.DataAccess;
using TradingPlatform.Dtos.Category;
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
