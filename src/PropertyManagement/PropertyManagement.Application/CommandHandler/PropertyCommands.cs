using AutoMapper;
using FluentResults;
using PropertyManagement.Application.Commands;
using PropertyManagement.Application.Errors;
using PropertyManagement.Application.Response;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Domain.Repositories;
using PropertyManagement.Domain.Services;
using MediatR;
using PropertyManagement.Domain.Events;

namespace PropertyManagement.Application.CommandHandler
{
    public class PropertyCommands : IPropertyCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PropertyCommands(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<PropertyResponse> AddPropertyAsync(string unit, string building, CancellationToken cancellationToken)
        {
            ApartmentUnit property = ApartmentUnit.Create(unit, building);
            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new ApartmentUnitCreated(building, unit), cancellationToken);
            return _mapper.Map<PropertyResponse>(property);
        }

        public async Task<Result> DeletePropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }   
            _unitOfWork.Properties.DeleteAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new ApartmentUnitDeleted(property.Building, property.Unit), cancellationToken);
            return Result.Ok();

        }

        public async Task<Result> OccupyPropertyAsync(Guid propertyId, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Id == new ApartmentUnitId(propertyId));
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            ApartmentUnit occupiedProperty = propertyService.OccupyProperty(property);
            _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new ApartmentUnitUpdated(occupiedProperty.Building, occupiedProperty.Unit), cancellationToken);
            return Result.Ok();

        }

        public async Task<Result> UnderMaintenancePropertyAsync(Guid propertyId, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Id == new ApartmentUnitId(propertyId));
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            ApartmentUnit occupiedProperty = propertyService.UnderMaintenanceProperty(property);
            _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new ApartmentUnitUpdated(occupiedProperty.Building, occupiedProperty.Unit), cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> VacantPropertyAsync(Guid propertyId, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Id == new ApartmentUnitId(propertyId));
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            ApartmentUnit occupiedProperty = propertyService.VacantProperty(property);
            _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new ApartmentUnitUpdated(occupiedProperty.Building, occupiedProperty.Unit), cancellationToken);
            return Result.Ok();
        }
    }
}
