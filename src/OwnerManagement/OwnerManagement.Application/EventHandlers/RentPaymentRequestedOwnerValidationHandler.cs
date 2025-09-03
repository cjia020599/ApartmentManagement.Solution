using FinancialManagement.Domain.Events;
using MediatR;
using OwnerManagement.Domain.Repositories;
using OwnerManagement.Domain.ValueObjects;

namespace OwnerManagement.Application.EventHandlers
{
    public class RentPaymentRequestedOwnerValidationHandler : INotificationHandler<RentPaymentRequestedDomainEvent>
    {
        private readonly IOwnerRespository _ownerRepository;
        public RentPaymentRequestedOwnerValidationHandler(IOwnerRespository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task Handle(RentPaymentRequestedDomainEvent notification, CancellationToken cancellationToken)
        {
            var owners = await _ownerRepository.GetAllAsync();
            var owner = owners.Find(o => o.Id == new OwnerId(notification.OwnerId));
            if (owner == null)
                throw new Exception("Owner does not exist.");
        }
    }
}
