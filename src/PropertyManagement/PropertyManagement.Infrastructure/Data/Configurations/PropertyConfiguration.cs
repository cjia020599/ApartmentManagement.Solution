using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Configurations
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
