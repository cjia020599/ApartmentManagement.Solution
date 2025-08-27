using Microsoft.EntityFrameworkCore;
using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Infrastructure.Data
{
    public class TenantAndLeaseDbContext : DbContext
    {
        public TenantAndLeaseDbContext(DbContextOptions<TenantAndLeaseDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TenantAndLease");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantAndLeaseDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
    }
}
