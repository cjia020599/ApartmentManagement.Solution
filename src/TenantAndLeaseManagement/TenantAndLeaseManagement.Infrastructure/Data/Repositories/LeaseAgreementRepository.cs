using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.Repositories;

namespace TenantAndLeaseManagement.Infrastructure.Data.Repositories
{
    public class LeaseAgreementRepository : ILeaseAgreementRepository
    {
        public Task CreateAsync(LeaseAgreement leaseAgreement)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaseAgreement>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task RenewAsync(LeaseAgreement leaseAgreement)
        {
            throw new NotImplementedException();
        }

        public Task TerminateAsync(LeaseAgreement leaseAgreement)
        {
            throw new NotImplementedException();
        }
    }
}
