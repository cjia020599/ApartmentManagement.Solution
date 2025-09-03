using MediatR;
using OwnerManagement.Domain.Entities;
using OwnerManagement.Domain.Repositories;
using PropertyManagement.Domain.Events;

namespace OwnerManagement.Application.EventHandlers
{
    public class ApartmentUnitCreatedHandler : INotificationHandler<ApartmentUnitCreated>
    {
        private readonly IUnitOFWork _unitOfWork;
        public ApartmentUnitCreatedHandler(IUnitOFWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ApartmentUnitCreated notification, CancellationToken cancellationToken)
        {
            var existing = (await _unitOfWork.IndividualUnits.GetAllAsync())
                .FirstOrDefault(i => i.Building == notification.Building && i.Unit == notification.Unit);
            if (existing is not null) return;
            var iu = IndividualUnit.Create(notification.Unit, notification.Building);
            await _unitOfWork.IndividualUnits.AddAsync(iu);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public class ApartmentUnitUpdatedHandler : INotificationHandler<ApartmentUnitUpdated>
    {
        private readonly IUnitOFWork _unitOfWork;
        public ApartmentUnitUpdatedHandler(IUnitOFWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ApartmentUnitUpdated notification, CancellationToken cancellationToken)
        {
            var individualUnits = await _unitOfWork.IndividualUnits.GetAllAsync();
            var iu = individualUnits.FirstOrDefault(i => i.Building == notification.Building && i.Unit == notification.Unit);
            if (iu is null) return;
            iu.Update(notification.Unit, notification.Building);
            _unitOfWork.IndividualUnits.UpdateAsync(iu);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public class ApartmentUnitDeletedHandler : INotificationHandler<ApartmentUnitDeleted>
    {
        private readonly IUnitOFWork _unitOfWork;
        public ApartmentUnitDeletedHandler(IUnitOFWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(ApartmentUnitDeleted notification, CancellationToken cancellationToken)
        {
            var individualUnits = await _unitOfWork.IndividualUnits.GetAllAsync();
            var iu = individualUnits.FirstOrDefault(i => i.Building == notification.Building && i.Unit == notification.Unit);
            if (iu is null) return;
            _unitOfWork.IndividualUnits.DeleteAsync(iu);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}


