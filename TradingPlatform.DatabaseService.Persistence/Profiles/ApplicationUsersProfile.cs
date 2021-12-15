using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.ApplicationUser;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ApplicationUsersProfile : Profile
    {
        public ApplicationUsersProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserCreateDto>().MaxDepth(2);
            CreateMap<ApplicationUserCreateDto, ApplicationUser>().MaxDepth(2);
        }
    }
}
