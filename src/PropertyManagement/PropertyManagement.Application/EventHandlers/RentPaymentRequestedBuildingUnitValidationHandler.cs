using FinancialManagement.Domain.Events;
using MediatR;
using PropertyManagement.Domain.Repositories;
using PropertyManagement.Domain.ValueObjects;

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
            var unit = units.FirstOrDefault(u => u.Id == new ApartmentUnitId(notification.IndividualUnitId));
            if (unit == null)
                throw new Exception("Unit or Building does not exist.");
        }
    }
}
