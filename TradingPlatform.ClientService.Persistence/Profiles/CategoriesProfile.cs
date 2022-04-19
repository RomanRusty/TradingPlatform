using AutoMapper;
using TradingPlatform.EntityContracts.Category;

namespace TradingPlatform.ClientService.Persistence.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoryCreateDto, CategoryReadDto>().MaxDepth(2);
            CreateMap<CategoryCreateDto, CategoryReadDto>().MaxDepth(2);
        }
    }
}
