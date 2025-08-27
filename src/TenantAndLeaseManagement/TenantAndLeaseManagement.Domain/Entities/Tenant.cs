using TenantAndLeaseManagement.Domain.Exceptions;
using TenantAndLeaseManagement.Domain.ValueObjects;

namespace TenantAndLeaseManagement.Domain.Entities
{
    public class Tenant
    {
        public TenantId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string PhoneNumber { get; private set; } = null!;
        public List<LeaseAgreement> LeaseAgreements { get; private set; } = [];
        protected Tenant() { } 
        private Tenant(string name, string email, string phoneNumber)
        {
            Id = new TenantId(Guid.NewGuid());
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public static Tenant Create(string name, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidInputException("Name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidInputException("Invalid email address.");
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 10)
                throw new InvalidInputException("Invalid phone number." );
            return new Tenant(name, email, phoneNumber);
        }
        public static Tenant Update(Tenant existingTenant, string name, string email, string phoneNumber)
        {
            if (existingTenant == null)
                throw new InvalidInputException("Existing tenant cannot be null.");
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidInputException("Name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidInputException("Invalid email address.");
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 10)
                throw new InvalidInputException("Invalid phone number.");
            existingTenant.Name = name;
            existingTenant.Email = email;
            existingTenant.PhoneNumber = phoneNumber;
            return existingTenant;
        }
        public static Tenant Delete(Tenant existingTenant)
        {
            if (existingTenant == null)
                throw new InvalidInputException("Existing tenant cannot be null.");
            return existingTenant;
        }
    }
}
