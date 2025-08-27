using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Repositories;

namespace Property.Infrastructure.Data.Repositories
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
