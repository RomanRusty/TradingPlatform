using AutoMapper;
using TradingPlatform.Contracts.Category;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Persistence.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<CategoryReadDto, Category>(); 
            CreateMap<Category, CategoryReadDto>(); 


        }
    }
}
