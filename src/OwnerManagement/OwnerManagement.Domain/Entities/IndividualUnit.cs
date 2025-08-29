using OwnerManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.Entities
{
    public class IndividualUnit
    {
        public IndividualUnitId Id { get; set; } = null!;
        public string Building { get; set; } = null!;
        public string Unit { get; set; } = null!;
    }
}
