using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Domain.Services
{
    public class ChangeStatusService
    {
        public ApartmentUnit OccupyProperty(ApartmentUnit property)
        {
            property.Update(property.Unit, "Occupied", property.Building);
            return property;
        }
        public ApartmentUnit VacantProperty(ApartmentUnit property)
        {
            property.Update(property.Unit, "Vacant", property.Building);
            return property;
        }
        public ApartmentUnit UnderMaintenanceProperty(ApartmentUnit property)
        {
            property.Update(property.Unit, "Under Maintenance", property.Building);
            return property;
        }
    }
}
