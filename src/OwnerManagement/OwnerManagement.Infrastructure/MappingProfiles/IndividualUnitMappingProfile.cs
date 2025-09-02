using AutoMapper;

namespace OwnerManagement.Infrastructure.MappingProfiles
{
    public class IndividualUnitMappingProfile : Profile
    {
        public IndividualUnitMappingProfile() { 
            CreateMap<Domain.Entities.IndividualUnit, Application.Response.IndividualUnitResponse>()
                .ForMember(i => i.Id, options => options.MapFrom(i => i.Id.Value));
        }
    }
}
