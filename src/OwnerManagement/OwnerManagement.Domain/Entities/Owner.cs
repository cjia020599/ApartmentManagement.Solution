using OwnerManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerManagement.Domain.Entities
{
    public class Owner
    {
        public OwnerId Id { get; private set; } = null!;
        public string Name { get; set; } = null!;
        public List<IndividualUnit> individualUnits { get; set; } = [];
    }
}
