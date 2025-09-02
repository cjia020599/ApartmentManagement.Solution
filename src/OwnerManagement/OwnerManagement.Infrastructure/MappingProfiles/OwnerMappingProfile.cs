using AutoMapper;
using OwnerManagement.Application.Response;
using OwnerManagement.Domain.Entities;

namespace OwnerManagement.Infrastructure.MappingProfiles
{
    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile()
        {
            CreateMap<Owner, OwnerResponse>()
                .ForMember(o => o.Id, options => options.MapFrom(o => o.Id.Value));
        }
    }
}
