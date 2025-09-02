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
                .ForMember(rp => rp.Id, options => options.MapFrom(rp => rp.Id.Value));
        }
    }
}
