using FinancialManagement.Domain.Entities;

namespace FinancialManagement.Domain.Repositories
{
    public interface IRentPaymentRepository
    {
        Task<List<RentPayment>> GetAllAsync();
        Task AddAsync(RentPayment rentPayment);
    }
}
