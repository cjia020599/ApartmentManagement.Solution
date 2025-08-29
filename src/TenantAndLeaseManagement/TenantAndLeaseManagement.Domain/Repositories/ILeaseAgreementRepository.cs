using TenantAndLeaseManagement.Domain.Entities;

namespace TenantAndLeaseManagement.Domain.Repositories
{
    public interface ILeaseAgreementRepository
    {
        Task<List<LeaseAgreement>> GetAllAsync();
        Task CreateAsync(LeaseAgreement leaseAgreement);
        void RenewAsync(LeaseAgreement leaseAgreement);
        void TerminateAsync(LeaseAgreement leaseAgreement);
    }
}
