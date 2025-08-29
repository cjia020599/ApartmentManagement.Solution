using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantAndLeaseManagement.Application.Response;

namespace TenantAndLeaseManagement.Application.Commands
{
    public interface ILeaseCommands
    {
        public Task<LeaseAgreementResponse> CreateLeaseAsync(string tenantName, string ownerName, DateTime creationDate, string building, string unit, double monthlyRent, CancellationToken cancellationToken);
        public Task<LeaseAgreementResponse?> RenewLeaseAsync(Guid leaseId, DateTime newTerminationDate, double? newMonthlyRent, CancellationToken cancellationToken);
        public Task<LeaseAgreementResponse?> TerminateLeaseAsync(Guid leaseId, CancellationToken cancellationToken);
    }
}
