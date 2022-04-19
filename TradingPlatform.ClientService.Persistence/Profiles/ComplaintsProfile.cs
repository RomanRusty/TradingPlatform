using AutoMapper;
using TradingPlatform.EntityContracts.Complaint;

namespace TradingPlatform.ClientService.Persistence.Profiles
{
    public class ComplaintsProfile : Profile
    {
        public ComplaintsProfile()
        {
            CreateMap<ComplaintCreateDto, ComplaintReadDto>().MaxDepth(2);

            CreateMap<ComplaintReadDto, ComplaintCreateDto>().MaxDepth(2);
        }
    }
}
