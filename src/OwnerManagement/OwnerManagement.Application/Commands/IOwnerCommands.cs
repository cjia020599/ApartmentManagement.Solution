using FluentResults;
using OwnerManagement.Application.Response;

namespace OwnerManagement.Application.Commands
{
    public interface IOwnerCommands
    {
        public Task<OwnerResponse> AddOwnerAsync(string name, CancellationToken cancellationToken);
        public Task<Result> UpdateOwnerAsync(Guid ownerId,string name, CancellationToken cancellationToken);
        public Task<Result> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken);
        public Task<Result> AssignUnitToOwnerAsync(Guid ownerId, Guid individualUnitId, CancellationToken cancellationToken);
        public Task<Result> RemoveUnitFromOwnerAsync(Guid ownerId, Guid individualUnitId, CancellationToken cancellationToken);
    }
}
