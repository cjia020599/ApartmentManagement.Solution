using AutoMapper;
using FinancialManagement.Application.Response;
using FinancialManagement.Domain.Entities;

namespace FinancialManagement.Infrastructure.MappingProfiles
{
    public class RentPaymentMappingProfile : Profile
    {
        public RentPaymentMappingProfile()
        {
            CreateMap<RentPayment, RentPaymentResponse>()
                .ForMember(rp => rp.Id, options => options.MapFrom(rp => rp.Id.Value))
                .ForMember(rp => rp.Unit, options => options.MapFrom(rp => rp.Unit))
                .ForMember(rp => rp.Building, options => options.MapFrom(rp => rp.Building))
                .ForMember(rp => rp.TenantId, options => options.MapFrom(rp => rp.TenantId))
                .ForMember(rp => rp.OwnerId, options => options.MapFrom(rp => rp.OwnerId));
        }
    }
}
