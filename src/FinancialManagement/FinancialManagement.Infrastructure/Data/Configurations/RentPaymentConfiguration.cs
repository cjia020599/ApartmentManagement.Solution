using FinancialManagement.Domain.Entities;
using FinancialManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialManagement.Infrastructure.Data.Configurations
{
    public class RentPaymentConfiguration : IEntityTypeConfiguration<RentPayment>
    {
        public void Configure(EntityTypeBuilder<RentPayment> rentPayment)
        {
            rentPayment.HasKey(rp => rp.Id);
            rentPayment.Property(rp => rp.Id)
                .HasConversion(id => id.Value, value => new RentPaymentId(value));
        }
    }
}
