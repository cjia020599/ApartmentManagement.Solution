using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Application.Response
{
    public class IndividualUnitResponse
    {
        public Guid Id { get; set; }
        public string Building { get; set; } = null!;
        public string Unit { get; set; } = null!;

    }
}
