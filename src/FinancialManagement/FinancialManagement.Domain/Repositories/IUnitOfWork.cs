namespace FinancialManagement.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IRentPaymentRepository RentPayments { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
