using FinancialManagement.Domain.ValueObjects;

namespace FinancialManagement.Domain.Entities
{
    public class RentPayment
    {
        public RentPaymentId Id { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid TenantId { get; set; }
        public Guid IndividualUnitId { get; set; }
        public Guid OwnerId { get; set; }
        protected RentPayment() { }
        public static RentPayment Create(double amount, DateTime paymentDate, Guid tenantId, Guid individualUnitId, Guid ownerId)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            return new RentPayment
            {
                Id = new RentPaymentId(Guid.NewGuid()),
                Amount = amount,
                PaymentDate = paymentDate,
                TenantId = tenantId,
                IndividualUnitId = individualUnitId,
                OwnerId = ownerId
            };
        }
    }
}
