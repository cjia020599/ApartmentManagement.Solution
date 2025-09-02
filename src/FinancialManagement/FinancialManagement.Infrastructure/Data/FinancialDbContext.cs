using FinancialManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Infrastructure.Data
{
    public class FinancialDbContext: DbContext
    {
        public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Financial");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<RentPayment> RentPayments { get; set; }
    }
}
