using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.ValueObjects;

namespace TenantAndLeaseManagement.Infrastructure.Data.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> tenant)
        {
            tenant.HasKey(t => t.Id);
            tenant.Property(t => t.Id)
                .HasConversion(id => id.Value, value => new TenantId(value));
        }
    }
}
