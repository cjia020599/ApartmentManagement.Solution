using MediatR;

namespace FinancialManagement.Domain.Events
{
    public class RentPaymentRequestedDomainEvent : INotification
    {
        public Guid OwnerId { get; }
        public Guid TenantId { get; }
        public Guid IndividualUnitId { get; }
        public double Amount { get; }
        public DateTime PaymentDate { get; }

        public RentPaymentRequestedDomainEvent(Guid ownerId, Guid individualUnitId, Guid tenantId, double amount, DateTime paymentDate)
        {
            OwnerId = ownerId;
            TenantId = tenantId;
            IndividualUnitId = individualUnitId;
            Amount = amount;
            PaymentDate = paymentDate;
        }
    }
}
