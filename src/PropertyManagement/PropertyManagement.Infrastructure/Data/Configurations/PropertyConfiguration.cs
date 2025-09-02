using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Domain.ValueObjects;

namespace PropertyManagement.Infrastructure.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<ApartmentUnit>
    {
        public void Configure(EntityTypeBuilder<ApartmentUnit> property)
        {
            property.HasKey(p => p.Id);
            property.Property(p => p.Id)
                .HasConversion(id => id.Value, value => new ApartmentUnitId(value));
        }
    }
}
