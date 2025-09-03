using FinancialManagement.Domain.Events;
using MediatR;
using TenantAndLeaseManagement.Domain.Repositories;

namespace TenantAndLeaseManagement.Application.EventHandlers
{
    public class RentPaymentRequestedTenantValidationHandler : INotificationHandler<RentPaymentRequestedDomainEvent>
    {
        private readonly ITenantRepository _tenantRepository;
        public RentPaymentRequestedTenantValidationHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task Handle(RentPaymentRequestedDomainEvent notification, CancellationToken cancellationToken)
        {
            var tenants = await _tenantRepository.GetAllAsync();
            var tenant = tenants.FirstOrDefault(t => t.Id.Value == notification.TenantId);
            if (tenant == null)
                throw new Exception("Tenant does not exist.");
        }
    }
}
