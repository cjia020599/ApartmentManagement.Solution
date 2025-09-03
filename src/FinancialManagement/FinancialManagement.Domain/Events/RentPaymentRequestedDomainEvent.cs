using MediatR;

namespace FinancialManagement.Domain.Events
{
    public class RentPaymentRequestedDomainEvent : INotification
    {
        public Guid OwnerId { get; }
        public Guid TenantId { get; }
        public string Building { get; } = null!;
        public string Unit { get; } = null!;
        public double Amount { get; }
        public DateTime PaymentDate { get; }

        public RentPaymentRequestedDomainEvent(Guid ownerId,string building, string unit, Guid tenantId, double amount, DateTime paymentDate)
        {
            OwnerId = ownerId;
            TenantId = tenantId;
            Building = building;
            Unit = unit;
            Amount = amount;
            PaymentDate = paymentDate;
        }
    }
}
