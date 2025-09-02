using PropertyManagement.Domain.ValueObjects;

namespace PropertyManagement.Domain.Entities
{
    public class ApartmentUnit
    {
        public ApartmentUnitId Id { get; private set; } = null!;
        public string Building { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? Owner { get; set; }
        public string? Tenant { get; set; }

        protected ApartmentUnit() { }

        public static ApartmentUnit Create(string unit, string building)
        {
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be null or empty.", nameof(unit));
            if (string.IsNullOrWhiteSpace(building))
                throw new ArgumentException("Building cannot be null or empty.", nameof(building));

            return new ApartmentUnit
            {
                Id = new ApartmentUnitId(Guid.NewGuid()),
                Building = building,
                Unit = unit,
                Status = "Vacant"
            };
        }
        public void Update(string unit, string status, string building)
        {
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("Unit cannot be null or empty.", nameof(unit));
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status cannot be null or empty.", nameof(status));
            if (string.IsNullOrWhiteSpace(building))
                throw new ArgumentException("Building cannot be null or empty.", nameof(building));
            if (status == "Vacant" || status == "Occupied" || status == "Under maintenance")
            {
                Unit = unit;
                Status = status;
                Building = building;
                return;
            }
            throw new ArgumentException("Invalid Status. Status must be either 'Vacant', 'Occupied', or 'Under maintenance'.", nameof(status));
        }
    }
}
