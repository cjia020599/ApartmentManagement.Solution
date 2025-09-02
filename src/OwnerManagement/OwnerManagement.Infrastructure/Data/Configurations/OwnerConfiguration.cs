using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnerManagement.Domain.Entities;
using OwnerManagement.Domain.ValueObjects;

namespace OwnerManagement.Infrastructure.Data.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> owner)
        {
            owner.HasKey(o => o.Id);
            owner.Property(o => o.Id)
                .HasConversion(id => id.Value, value => new OwnerId(value));
            owner.Property(o => o.Name).IsRequired();
            //owner.HasMany(o => o.individualUnits)
            //    .WithOne(i => i)
            //    .UsingEntity(j => j.ToTable("OwnerIndividualUnits"));
        }
    }
}
