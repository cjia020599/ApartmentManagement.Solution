using FinancialManagement.Domain.ValueObjects;

namespace FinancialManagement.Application.Response
{
    public class RentPaymentResponse
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid TenantId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid UnitId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
