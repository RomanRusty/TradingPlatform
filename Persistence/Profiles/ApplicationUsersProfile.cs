using AutoMapper;
using TradingPlatform.DatabaseService.Contracts.ApplicationUser;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ApplicationUsersProfile : Profile
    {
        public ApplicationUsersProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserCreateDto>();
            CreateMap<ApplicationUserCreateDto, ApplicationUser>();
        }
    }
}
