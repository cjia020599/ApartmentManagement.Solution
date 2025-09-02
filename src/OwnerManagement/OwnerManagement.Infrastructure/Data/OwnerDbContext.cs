using Microsoft.EntityFrameworkCore;
using OwnerManagement.Domain.Entities;

namespace OwnerManagement.Infrastructure.Data
{
    public class OwnerDbContext : DbContext
    {
        public OwnerDbContext(DbContextOptions<OwnerDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Owner");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OwnerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<IndividualUnit> IndividualUnits { get; set; }
        }
}
