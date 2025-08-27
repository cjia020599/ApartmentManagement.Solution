using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITenantRepository Tenants { get; }
        ILeaseAgreementRepository LeaseAgreements { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
