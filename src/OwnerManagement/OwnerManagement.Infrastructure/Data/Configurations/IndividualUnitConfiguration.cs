using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerManagement.Domain.Entities;

namespace OwnerManagement.Infrastructure.Data.Configurations
{
    public class IndividualUnitConfiguration : IEntityTypeConfiguration<IndividualUnit>
    {
        public void Configure(EntityTypeBuilder<IndividualUnit> individualUnit)
        {
            individualUnit.HasKey(i => i.Id);
            individualUnit.Property(i => i.Id)
                .HasConversion(id => id.Value, value => new Domain.ValueObjects.IndividualUnitId(value));
            individualUnit.Property(i => i.Building).IsRequired();
            individualUnit.Property(i => i.Unit).IsRequired();
        }
    }
}
