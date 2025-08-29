using TenantAndLeaseManagement.Domain.ValueObjects;

namespace TenantAndLeaseManagement.Domain.Entities
{
    public class LeaseAgreement
    {
        public LeaseAgreementId Id { get; private set; } = null!;
        public string TenantName { get; private set; } = null!;
        public string OwnerName { get; private set; } = null!;
        public DateTime CreationDate { get; private set; }
        public DateTime TerminationDate { get; private set; }
        public string Building { get; private set; } = null!;
        public string Unit { get; private set; } = null!;
        public double MonthlyRent { get; private set; }
        protected LeaseAgreement() { }
        private LeaseAgreement(string tenantName, string ownerName, DateTime creationDate, DateTime terminationDate, string building, string unit, double monthlyRent)
        {
            Id = new LeaseAgreementId(Guid.NewGuid());
            TenantName = tenantName;
            OwnerName = ownerName;
            CreationDate = creationDate;
            TerminationDate = terminationDate;
            Building = building;
            Unit = unit;
            MonthlyRent = monthlyRent;
        }
        public static LeaseAgreement Create(string tenantName, string ownerName, DateTime creationDate, DateTime terminationDate, string building, string unit, double monthlyRent)
        {
            if (string.IsNullOrWhiteSpace(tenantName))
                throw new ArgumentException("Tenant name cannot be null or empty.", nameof(tenantName));
            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("Owner name cannot be null or empty.", nameof(ownerName));
            if (creationDate == default)
                throw new ArgumentException("Creation date cannot be default value.", nameof(creationDate));
            if (terminationDate == default || terminationDate <= creationDate)
                throw new ArgumentException("Termination date must be after creation date and cannot be default value.", nameof(terminationDate));
            if (string.IsNullOrWhiteSpace(building))
                throw new ArgumentException("Building cannot be null or empty.", nameof(building));
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be null or empty.", nameof(unit));
            if (monthlyRent <= 0)
                throw new ArgumentException("Monthly rent must be greater than zero.", nameof(monthlyRent));
            return new LeaseAgreement(tenantName, ownerName, creationDate, terminationDate, building, unit, monthlyRent);
        }
        public static LeaseAgreement Renew(LeaseAgreement existingLease, DateTime newTerminationDate, double newMonthlyRent)
        {
            if (existingLease == null)
                throw new ArgumentNullException(nameof(existingLease), "Existing lease cannot be null.");
            if (newTerminationDate == default || newTerminationDate <= existingLease.TerminationDate)
                throw new ArgumentException("New termination date must be after the existing termination date and cannot be default value.", nameof(newTerminationDate));
            if (newMonthlyRent <= 0)
                throw new ArgumentException("New monthly rent must be greater than zero.", nameof(newMonthlyRent));
            return new LeaseAgreement(existingLease.TenantName, existingLease.OwnerName, existingLease.CreationDate, newTerminationDate, existingLease.Building, existingLease.Unit, newMonthlyRent);
        }
        public static LeaseAgreement Terminate(LeaseAgreement existingLease)
        {
            if (existingLease == null)
                throw new ArgumentNullException(nameof(existingLease), "Existing lease cannot be null.");
            return new LeaseAgreement(existingLease.TenantName, existingLease.OwnerName, existingLease.CreationDate, DateTime.Now, existingLease.Building, existingLease.Unit, existingLease.MonthlyRent);
        }
    }
}
