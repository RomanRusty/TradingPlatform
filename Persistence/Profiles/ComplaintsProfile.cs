using AutoMapper;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
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
