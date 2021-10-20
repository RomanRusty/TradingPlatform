using AutoMapper;
using TradingPlatform.DataAccess;
using TradingPlatform.Dtos;
namespace TradingPlatform.Profiles
{
    public class ApplicationUsersProfile:Profile
    {
        public ApplicationUsersProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserCreateDto>();
            CreateMap<ApplicationUserCreateDto, ApplicationUser>();
        }
    }
}
