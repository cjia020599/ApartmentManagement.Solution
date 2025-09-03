using MediatR;
using OwnerManagement.Domain.Events;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Domain.Repositories;

namespace PropertyManagement.Application.EventHandlers
{
    public class IndividualUnitCreatedHandler : INotificationHandler<IndividualUnitCreated>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndividualUnitCreatedHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(IndividualUnitCreated notification, CancellationToken cancellationToken)
        {
            var all = await _unitOfWork.Properties.GetAllAsync();
            var existing = all.FirstOrDefault(p => p.Building == notification.Building && p.Unit == notification.Unit);
            if (existing is not null) return;
            var property = ApartmentUnit.Create(notification.Unit, notification.Building);
            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public class IndividualUnitUpdatedHandler : INotificationHandler<IndividualUnitUpdated>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndividualUnitUpdatedHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(IndividualUnitUpdated notification, CancellationToken cancellationToken)
        {
            var all = await _unitOfWork.Properties.GetAllAsync();
            var prop = all.FirstOrDefault(p => p.Building == notification.Building && p.Unit == notification.Unit);
            if (prop is null) return;
            prop.Update(notification.Unit, prop.Status, notification.Building);
            _unitOfWork.Properties.UpdateAsync(prop);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public class IndividualUnitDeletedHandler : INotificationHandler<IndividualUnitDeleted>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndividualUnitDeletedHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(IndividualUnitDeleted notification, CancellationToken cancellationToken)
        {
            var all = await _unitOfWork.Properties.GetAllAsync();
            // No building/unit provided; cannot match reliably. In a follow-up, migrate Property to store IndividualUnitId for precise sync.
            // For now, do nothing.
        }
    }
}


