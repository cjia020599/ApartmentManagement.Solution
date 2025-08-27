using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Domain.Repositories
{
    public interface ILeaseAgreementRepository
    {
        Task<List<LeaseAgreement>> GetAllAsync();
        Task CreateAsync(LeaseAgreement leaseAgreement);
        Task RenewAsync(LeaseAgreement leaseAgreement);
        Task TerminateAsync(LeaseAgreement leaseAgreement);
    }
}
