using AutoMapper;
using TradingPlatform.Contracts.Complaint;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Persistence.Profiles
{
    public class ComplaintsProfile : Profile
    {
        public ComplaintsProfile()
        {
            CreateMap<Complaint, ComplaintReadDto>();
            CreateMap<ComplaintCreateDto, Complaint>();
        }
    }
}
