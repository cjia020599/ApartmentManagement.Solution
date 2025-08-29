using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.Exceptions
{
    public class OwnerNotFoundException(string message) : Exception(message)
    {
    }
}
