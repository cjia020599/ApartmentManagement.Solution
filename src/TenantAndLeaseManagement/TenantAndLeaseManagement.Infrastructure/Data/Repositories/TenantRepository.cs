using Microsoft.EntityFrameworkCore;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.Repositories;

namespace TenantAndLeaseManagement.Infrastructure.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly TenantAndLeaseDbContext _context;

        public TenantRepository(TenantAndLeaseDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
        }

        public void DeleteAsync(Tenant tenant)
        {
            _context.Tenants.Remove(tenant);
        }

        public async Task<List<Tenant>> GetAllAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public void UpdateAsync(Tenant tenant)
        {
            _context.Tenants.Update(tenant);
        }
    }
}
