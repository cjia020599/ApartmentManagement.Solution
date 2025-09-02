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
        public List<IndividualUnit> IndividualUnits { get; set; } = [];
        protected Owner() { }
        public static Owner Create(string name, List<IndividualUnit> individualUnits)
        {
            Owner owner = new()
            {
                Id = new OwnerId(Guid.NewGuid()),
                Name = name,
                IndividualUnits = individualUnits
            };
            return owner;
        }
        public void Update(string name, List<IndividualUnit> individualUnits)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            Name = name;
            this.IndividualUnits = individualUnits;
        }
        public Owner AddIndividualUnit(Owner owner,IndividualUnit individualUnit)
        {
            if (individualUnit == null)
                throw new ArgumentNullException(nameof(individualUnit), "Individual unit cannot be null.");
            owner.IndividualUnits.Add(individualUnit);
            return owner;
        }
        public Owner RemoveIndividualUnit(Owner owner, IndividualUnit individualUnit)
        {
            if (individualUnit == null)
                throw new ArgumentNullException(nameof(individualUnit), "Individual unit cannot be null.");
            owner.IndividualUnits.Remove(individualUnit);
            return owner;
        }
    }
}
