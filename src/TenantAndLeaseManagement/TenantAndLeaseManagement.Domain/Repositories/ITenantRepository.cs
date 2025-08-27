using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task<List<Tenant>> GetAllAsync();
        Task AddAsync(Tenant tenant);
        void DeleteAsync(Tenant tenant);
        void UpdateAsync(Tenant tenant);
    }
}
