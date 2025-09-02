using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Infrastructure.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Property");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PropertyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ApartmentUnit> Properties { get; set; }
    }
}
