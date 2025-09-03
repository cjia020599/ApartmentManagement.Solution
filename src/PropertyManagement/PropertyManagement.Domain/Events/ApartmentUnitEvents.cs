using MediatR;

namespace PropertyManagement.Domain.Events
{
    public class ApartmentUnitCreated : INotification
    {
        public string Building { get; }
        public string Unit { get; }
        public ApartmentUnitCreated(string building, string unit)
        {
            Building = building;
            Unit = unit;
        }
    }

    public class ApartmentUnitUpdated : INotification
    {
        public string Building { get; }
        public string Unit { get; }
        public ApartmentUnitUpdated(string building, string unit)
        {
            Building = building;
            Unit = unit;
        }
    }

    public class ApartmentUnitDeleted : INotification
    {
        public string Building { get; }
        public string Unit { get; }
        public ApartmentUnitDeleted(string building, string unit)
        {
            Building = building;
            Unit = unit;
        }
    }
}


