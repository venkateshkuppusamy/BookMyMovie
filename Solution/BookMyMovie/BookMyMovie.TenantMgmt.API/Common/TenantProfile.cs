
   using AutoMapper;
using BookMyMovie.TenantMgmt.API.API.Models;
using BookMyMovie.TenantMgmt.API.Business.Domain;
using BookMyMovie.TenantMgmt.API.Repositories.Entities;

namespace BookMyMovie.TenantMgmt.API.Common
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, TenantDto>().ReverseMap();
            CreateMap<Tenant, TenantEntity>().ReverseMap();
            CreateMap<TenantEntity, Tenant>();
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
           .ForMember("Items", opt => opt.MapFrom("Items"));
        }
    }
}
