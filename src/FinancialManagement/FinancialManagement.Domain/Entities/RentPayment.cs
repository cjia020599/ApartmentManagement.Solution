using FinancialManagement.Domain.ValueObjects;

namespace FinancialManagement.Domain.Entities
{
    public class RentPayment
    {
        public RentPaymentId Id { get; set; } = null!;
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid TenantId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid UnitId { get; set; }
        public Guid OwnerId { get; set; }
        protected RentPayment() { }
        public static RentPayment Create(double amount, DateTime paymentDate, Guid tenantId, Guid buildingId, Guid unitId, Guid ownerId)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            if (paymentDate > DateTime.Now)
                throw new ArgumentException("Payment date cannot be in the future.", nameof(paymentDate));
            if (tenantId == Guid.Empty)
                throw new ArgumentException("Tenant ID cannot be empty.", nameof(tenantId));
            if (buildingId == Guid.Empty)
                throw new ArgumentException("Building ID cannot be empty.", nameof(buildingId));
            if (unitId == Guid.Empty)
                throw new ArgumentException("Unit ID cannot be empty.", nameof(unitId));
            if (ownerId == Guid.Empty)
                throw new ArgumentException("Owner ID cannot be empty.", nameof(ownerId));
            return new RentPayment
            {
                Id = new RentPaymentId(Guid.NewGuid()),
                Amount = amount,
                PaymentDate = paymentDate,
                TenantId = tenantId,
                BuildingId = buildingId,
                UnitId = unitId,
                OwnerId = ownerId
            };
        }
    }
}
