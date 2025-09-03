using FinancialManagement.Domain.ValueObjects;

namespace FinancialManagement.Application.Response
{
    public class RentPaymentResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TenantId { get; set; } = null!;
        public string Building { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
    }
}
