using FluentResults;
using TenantAndLeaseManagement.Application.Response;

namespace TenantAndLeaseManagement.Application.Commands
{
    public interface ITenantCommands
    {
        public Task<TenantResponse> AddTenantAsync(string name, string email, string phoneNumber, CancellationToken cancellationToken);
        public Task<TenantResponse?> UpdateTenantAsync(Guid id, string name, string email, string phoneNumber, CancellationToken cancellationToken);
        public Task<Result> DeleteTenantAsync(Guid id, CancellationToken cancellationToken);
    }
}
