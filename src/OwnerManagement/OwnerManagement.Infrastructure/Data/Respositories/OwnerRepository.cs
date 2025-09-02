using Microsoft.EntityFrameworkCore;
using OwnerManagement.Domain.Entities;
using OwnerManagement.Domain.Repositories;

namespace OwnerManagement.Infrastructure.Data.Respositories
{
    public class OwnerRepository : IOwnerRespository
    {
        private readonly OwnerDbContext _context;

        public OwnerRepository(OwnerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public void DeleteAsync(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        public async Task<List<Owner>> GetAllAsync()
        {
            return await _context.Owners.Include(b => b.IndividualUnits).ToListAsync();
        }

        public void UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
        }
    }
}
