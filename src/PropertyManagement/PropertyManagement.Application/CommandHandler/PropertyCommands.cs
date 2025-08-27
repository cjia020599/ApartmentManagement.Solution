using AutoMapper;
using FluentResults;
using Property.Application.Commands;
using Property.Application.Errors;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.Services;

namespace Property.Application.CommandHandler
{
    public class PropertyCommands : IPropertyCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PropertyResponse> AddPropertyAsync(string unit, string building, CancellationToken cancellationToken)
        {
            ApartmentUnit property = ApartmentUnit.Create(unit, building);
            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
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
            return Result.Ok();

        }

        public async Task<Result> OccupyPropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            ApartmentUnit occupiedProperty = propertyService.OccupyProperty(property);
            _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();

        }

        public async Task<Result> UnderMaintenancePropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            ApartmentUnit occupiedProperty = propertyService.UnderMaintenanceProperty(property);
            _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> VacantPropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<ApartmentUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            ApartmentUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            ApartmentUnit occupiedProperty = propertyService.VacantProperty(property);
            _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
