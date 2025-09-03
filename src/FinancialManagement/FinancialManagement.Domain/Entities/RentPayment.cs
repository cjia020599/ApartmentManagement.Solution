using FinancialManagement.Domain.ValueObjects;

namespace FinancialManagement.Domain.Entities
{
    public class RentPayment
    {
        public RentPaymentId Id { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid TenantId { get; set; }
        public string Building { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public Guid OwnerId { get; set; }
        protected RentPayment() { }
        public static RentPayment Create(double amount, DateTime paymentDate, Guid tenantId, string building, string unit, Guid ownerId)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            if (string.IsNullOrWhiteSpace(building))
                throw new ArgumentException("Building cannot be empty.", nameof(building));
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be empty.", nameof(unit));
            return new RentPayment
            {
                Id = new RentPaymentId(Guid.NewGuid()),
                Amount = amount,
                PaymentDate = paymentDate,
                TenantId = tenantId,
                Building = building,
                Unit = unit,
                OwnerId = ownerId
            };
        }
    }
}
