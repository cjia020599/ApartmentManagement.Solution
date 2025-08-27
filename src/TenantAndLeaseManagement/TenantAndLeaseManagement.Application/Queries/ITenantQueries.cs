using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantAndLeaseManagement.Application.Response;

namespace TenantAndLeaseManagement.Application.Queries
{
    public interface ITenantQueries
    {
        Task<List<TenantResponse>> GetTenantByIdAsync(Guid? id);
    }
}
