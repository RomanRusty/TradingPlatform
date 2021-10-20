using AutoMapper;
using TradingPlatform.Domain.Entities;
using TradingPlatform.Dtos;
namespace TradingPlatform.Profiles
{
    public class ComplaintsProfile:Profile
    {
        public ComplaintsProfile()
        {
            CreateMap<Complaint, ComplaintReadDto>();
            CreateMap<ComplaintCreateDto, Complaint>();
        }
    }
}
