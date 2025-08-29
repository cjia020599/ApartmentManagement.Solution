using AutoMapper;
using TenantAndLeaseManagement.Application.Response;
using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Infrastructure.MappingProfiles
{
    public class LeaseAgreementMappingProfile : Profile
    {
        public LeaseAgreementMappingProfile()
        {
            CreateMap<LeaseAgreement, LeaseAgreementResponse>()
                .ForMember(l => l.Id, options => options.MapFrom(l => l.Id.Value));
        }
    }
}
