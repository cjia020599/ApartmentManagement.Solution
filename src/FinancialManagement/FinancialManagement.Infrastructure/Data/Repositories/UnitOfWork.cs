using FinancialManagement.Domain.Repositories;

namespace FinancialManagement.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancialDbContext _context;
        private readonly IRentPaymentRepository _rentPaymentRepository;

        public UnitOfWork(FinancialDbContext context, IRentPaymentRepository rentPaymentRepository)
        {
            _context = context;
            _rentPaymentRepository = rentPaymentRepository;
        }
        public IRentPaymentRepository RentPayments => _rentPaymentRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
