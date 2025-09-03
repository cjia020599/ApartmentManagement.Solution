using PropertyManagement.Application.Response;

namespace PropertyManagement.Application.Queries
{
    public interface IPropertyQueries
    {
        Task<PropertyResponse?> GetPropertyByIdAsync(Guid id);
        Task<List<PropertyResponse>> GetAllPropertiesAsync();
        Task<List<PropertyResponse>> GetAllVacantProperties();
        Task<List<PropertyResponse>> GetAllOccupiedProperties();
        Task<List<PropertyResponse>> GetAllUnderMaintenanceProperties();
    }
}
