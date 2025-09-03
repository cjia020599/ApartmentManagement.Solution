using FinancialManagement.Application.Response;

namespace FinancialManagement.Application.Queries
{
    public interface IRentPaymentQueries
    {
        Task<List<RentPaymentResponse>> GetAllRentPaymentsAsync();
        Task<RentPaymentResponse?> GetRentPaymentByIdAsync(Guid id);
        Task<List<RentPaymentResponse>> GetRentPaymentsByTenantAsync(Guid tenantId);
        Task<List<RentPaymentResponse>> GetRentPaymentsByIndividualUnitAsync(Guid individualUnitId);
        Task<List<RentPaymentResponse>> GetRentPaymentsByOwnerAsync(Guid ownerId);
    }
}
