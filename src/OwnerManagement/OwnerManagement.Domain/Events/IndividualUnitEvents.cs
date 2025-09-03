using MediatR;

namespace OwnerManagement.Domain.Events
{
    public class IndividualUnitCreated : INotification
    {
        public Guid IndividualUnitId { get; }
        public string Building { get; }
        public string Unit { get; }
        public IndividualUnitCreated(Guid individualUnitId, string building, string unit)
        {
            IndividualUnitId = individualUnitId;
            Building = building;
            Unit = unit;
        }
    }

    public class IndividualUnitUpdated : INotification
    {
        public Guid IndividualUnitId { get; }
        public string Building { get; }
        public string Unit { get; }
        public IndividualUnitUpdated(Guid individualUnitId, string building, string unit)
        {
            IndividualUnitId = individualUnitId;
            Building = building;
            Unit = unit;
        }
    }

    public class IndividualUnitDeleted : INotification
    {
        public Guid IndividualUnitId { get; }
        public IndividualUnitDeleted(Guid individualUnitId)
        {
            IndividualUnitId = individualUnitId;
        }
    }
}


