using AutoMapper;
using TradingPlatform.DatabaseService.Domain.Entities;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.DatabaseService.Persistence.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>()
                .ForMember(p=>p.CategoryId, opt=>opt.MapFrom(p=>p.Category != null ? p.Category.Id:default)).MaxDepth(2);

            CreateMap<ProductCreateDto, Product>()
                .ForPath(p => p.Category.Id, opt => opt.MapFrom(p => p.CategoryId)).MaxDepth(2);
        }
    }
}
