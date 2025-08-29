using AutoMapper;
using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Infrastructure.MappingProfiles
{
    public class TenantMappingProfile : Profile
    {
        public TenantMappingProfile()
        {
            CreateMap<Tenant, Application.Response.TenantResponse>()
                .ForMember(t => t.Id, options => options.MapFrom(t => t.Id.Value));
        }
    }
}
