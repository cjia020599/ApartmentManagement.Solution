using FluentResults;
using PropertyManagement.Application.Response;

namespace PropertyManagement.Application.Commands
{
    public interface IPropertyCommands
    {
        public Task<PropertyResponse> AddPropertyAsync(string unit, string building, CancellationToken cancellationToken);
        public Task<Result> DeletePropertyAsync(string unit, CancellationToken cancellationToken);
        public Task<Result> OccupyPropertyAsync(Guid propertyId, CancellationToken cancellationToken);
        public Task<Result> VacantPropertyAsync(Guid propertyId, CancellationToken cancellationToken);
        public Task<Result> UnderMaintenancePropertyAsync(Guid propertyId, CancellationToken cancellationToken);
    }
}
