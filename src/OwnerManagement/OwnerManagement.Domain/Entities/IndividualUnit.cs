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

        protected IndividualUnit() { }
        public static IndividualUnit Create(string unit, string building)
        {
            if (string.IsNullOrWhiteSpace(building))
                throw new ArgumentException("Building cannot be null or empty.", nameof(building));
            return new IndividualUnit
            {
                Id = new IndividualUnitId(Guid.NewGuid()),
                Building = building,
                Unit = unit
            };
        }
        public void Update(string unit, string building)
        {
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be null or empty.", nameof(unit));
            if (string.IsNullOrWhiteSpace(building))
                throw new ArgumentException("Building cannot be null or empty.", nameof(building));
            Unit = unit;
            Building = building;
        }
    }
}
