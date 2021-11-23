using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.ApplicationUser;

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
