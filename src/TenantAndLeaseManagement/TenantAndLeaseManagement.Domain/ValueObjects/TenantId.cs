using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Domain.ValueObjects
{
    public record TenantId (Guid Value)
    {
    }
}
