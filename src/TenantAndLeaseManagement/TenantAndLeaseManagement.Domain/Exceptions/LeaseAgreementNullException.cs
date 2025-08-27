using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Domain.Exceptions
{
    public class LeaseAgreementNullException(string message): Exception (message)
    {
    }
}
