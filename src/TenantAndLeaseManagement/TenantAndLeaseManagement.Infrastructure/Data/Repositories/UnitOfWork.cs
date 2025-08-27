using TenantAndLeaseManagement.Domain.Repositories;

namespace TenantAndLeaseManagement.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TenantAndLeaseDbContext _context;
        private readonly ITenantRepository _tenantRepository;
        private readonly ILeaseAgreementRepository _leaseAgreementRepository;

        public UnitOfWork(TenantAndLeaseDbContext context, ITenantRepository tenantRepository, ILeaseAgreementRepository leaseAgreementRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
            _leaseAgreementRepository = leaseAgreementRepository;
        }
        public ITenantRepository Tenants => _tenantRepository;

        public ILeaseAgreementRepository LeaseAgreements => _leaseAgreementRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
