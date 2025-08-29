using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.ValueObjects
{
    public record OwnerId(Guid Value)
    {
    }
}
