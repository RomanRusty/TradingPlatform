using AutoMapper;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryReadDto>().MaxDepth(2);
            CreateMap<CategoryCreateDto, Category>().MaxDepth(2);

            CreateMap<CategoryReadDto, Category>().MaxDepth(2); 
            CreateMap<Category, CategoryReadDto>().MaxDepth(2); 


        }
    }
}
