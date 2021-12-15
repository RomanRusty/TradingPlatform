using AutoMapper;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ComplaintsProfile : Profile
    {
        public ComplaintsProfile()
        {
            CreateMap<Complaint, ComplaintReadDto>()
                .ForMember(p => p.ProductId, opt => opt.MapFrom(p => p.Product != null ? p.Product.Id : default)).MaxDepth(2);

            CreateMap<ComplaintCreateDto, Complaint>().MaxDepth(2);
        }
    }
}
