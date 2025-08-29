using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Domain.Services
{
    public class LeaseService
    {
        public LeaseAgreement Lease(Tenant tenant, string owner,DateTime creationDate,DateTime terminationDate,string building,string unit,double monthlyRent) {
            return LeaseAgreement.Create(tenant.Name, owner,creationDate,terminationDate,building,unit,monthlyRent);
        }
    }
}
