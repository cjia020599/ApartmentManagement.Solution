using FinancialManagement.Application.Response;

namespace FinancialManagement.Application.Commands
{
    public interface IRentPaymentCommands
    {
        public Task<RentPaymentResponse> ProcessRentPaymentAsync(double amount, DateTime paymentDate, Guid tenantId, string building, string unit, Guid ownerId);
    }
}
