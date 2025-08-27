using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantAndLeaseManagement.Domain.Exceptions
{
    public class InvalidInputException(string message): Exception(message)
    {
    }
}
