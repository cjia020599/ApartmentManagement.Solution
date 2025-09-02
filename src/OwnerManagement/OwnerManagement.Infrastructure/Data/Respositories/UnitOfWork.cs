using OwnerManagement.Domain.Repositories;

namespace OwnerManagement.Infrastructure.Data.Respositories
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly OwnerDbContext _context;
        private readonly IOwnerRespository _ownerRepository;
        private readonly IIndividualUnitRepository _individualRepository;

        public UnitOfWork(OwnerDbContext context, IOwnerRespository ownerRepository, IIndividualUnitRepository individualUnitRepository)
        {
            _context = context;
            _ownerRepository = ownerRepository;
            _individualRepository = individualUnitRepository;
        }
        public IOwnerRespository Owners => _ownerRepository;

        public IIndividualUnitRepository IndividualUnits => _individualRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
