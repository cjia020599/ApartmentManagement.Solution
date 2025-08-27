using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.ValueObjects;

namespace TenantAndLeaseManagement.Infrastructure.Data.Configurations
{
    public class LeaseConfiguration : IEntityTypeConfiguration<LeaseAgreement>
    {
        public void Configure(EntityTypeBuilder<LeaseAgreement> lease)
        {
            lease.HasKey(l => l.Id);
            lease.Property(l => l.Id)
                .HasConversion(id => id.Value, value => new LeaseAgreementId(value));
        }
    }
}
