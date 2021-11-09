using AutoMapper;
using TradingPlatform.Contracts.ApplicationUser;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Persistence.Profiles
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
