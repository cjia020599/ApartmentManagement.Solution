using PropertyManagement.Domain.Entities;

namespace PropertyManagement.Domain.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<ApartmentUnit>> GetAllAsync();
        Task AddAsync(ApartmentUnit propertyUnit);
        void DeleteAsync(ApartmentUnit propertyUnit);
        void UpdateAsync(ApartmentUnit propertyUnit);
    }
}
