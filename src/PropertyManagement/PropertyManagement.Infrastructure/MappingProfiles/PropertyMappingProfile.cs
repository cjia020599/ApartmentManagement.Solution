using AutoMapper;
using PropertyManagement.Application.Response;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Infrastructure.MappingProfiles
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<ApartmentUnit, PropertyResponse>()
                .ForMember(p => p.Id, options => options.MapFrom(p => p.Id.Value));
        }
    }
}
