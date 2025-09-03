using Microsoft.EntityFrameworkCore;
using OwnerManagement.Domain.Entities;
using OwnerManagement.Domain.Repositories;

namespace OwnerManagement.Infrastructure.Data.Respositories
{
    public class IndividualUnitRepository : IIndividualUnitRepository
    {
        private readonly OwnerDbContext _context;

        public IndividualUnitRepository(OwnerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(IndividualUnit individualUnit)
        {
            await _context.IndividualUnits.AddAsync(individualUnit);
        }

        public void DeleteAsync(IndividualUnit individualUnit)
        {
            _context.IndividualUnits.Remove(individualUnit);
        }

        public Task<List<IndividualUnit>> GetAllAsync()
        {
           return _context.IndividualUnits.ToListAsync();
        }

        public void UpdateAsync(IndividualUnit individualUnit)
        {
            _context.IndividualUnits.Update(individualUnit);    
        }

        public Task<bool> ExistsByIdAsync(Guid individualUnitId, CancellationToken cancellationToken)
        {
            return _context.IndividualUnits.AnyAsync(iu => iu.Id.Value == individualUnitId, cancellationToken);
        }
    }
}
