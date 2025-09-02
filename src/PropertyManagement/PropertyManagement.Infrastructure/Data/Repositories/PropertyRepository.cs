using Microsoft.EntityFrameworkCore;
using PropertyManagement.Domain.Entities;
using PropertyManagement.Domain.Repositories;

namespace PropertyManagement.Infrastructure.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyDbContext _context;

        public PropertyRepository(PropertyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ApartmentUnit propertyUnit)
        {
            await _context.Properties.AddAsync(propertyUnit);
        }

        public void DeleteAsync(ApartmentUnit propertyUnit)
        {
            _context.Properties.Remove(propertyUnit);
        }

        public async Task<List<ApartmentUnit>> GetAllAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public void UpdateAsync(ApartmentUnit propertyUnit)
        {
             _context.Properties.Update(propertyUnit);
        }
    }
}
