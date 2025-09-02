using FluentResults;
using OwnerManagement.Application.Response;

namespace OwnerManagement.Application.Commands
{
    public interface IIndividualUnitCommands
    {
        public Task<IndividualUnitResponse> AddIndividualUnitAsync(string building, string unit, CancellationToken cancellationToken);
        public Task<Result> UpdateIndividualUnitAsync(Guid individualUnitId, string building, string unit, CancellationToken cancellationToken);
        public Task<Result> DeleteIndividualUnitAsync(Guid individualUnitId, CancellationToken cancellationToken);
    }
}
