using FinancialManagement.Domain.Events;
using MediatR;
using PropertyManagement.Domain.Repositories;

namespace PropertyManagement.Application.EventHandlers
{
    public class RentPaymentRequestedBuildingUnitValidationHandler : INotificationHandler<RentPaymentRequestedDomainEvent>
    {
        private readonly IPropertyRepository _propertyRepository;
        public RentPaymentRequestedBuildingUnitValidationHandler(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task Handle(RentPaymentRequestedDomainEvent notification, CancellationToken cancellationToken)
        {
            var units = await _propertyRepository.GetAllAsync();
            var unit = units.FirstOrDefault(u => u.Unit == notification.Unit && u.Building == notification.Building);
            if (unit == null)
                throw new Exception("Unit or Building does not exist.");
        }
    }
}
