using FinancialManagement.Application.Response;

namespace FinancialManagement.Application.Queries
{
    public interface IRentPaymentQueries
    {
        Task<List<RentPaymentResponse>> GetAllRentPaymentsAsync();
        Task<RentPaymentResponse?> GetRentPaymentByIdAsync(Guid id);
        Task<List<RentPaymentResponse>> GetRentPaymentsByTenantIdAsync(Guid tenantId);
        Task<List<RentPaymentResponse>> GetRentPaymentsByBuildingIdAsync(Guid buildingId);
        Task<List<RentPaymentResponse>> GetRentPaymentsByUnitIdAsync(Guid unitId);
        Task<List<RentPaymentResponse>> GetRentPaymentsByOwnerIdAsync(Guid ownerId);
    }
}
