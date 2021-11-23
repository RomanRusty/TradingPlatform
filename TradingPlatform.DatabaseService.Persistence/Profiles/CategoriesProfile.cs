using AutoMapper;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
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
