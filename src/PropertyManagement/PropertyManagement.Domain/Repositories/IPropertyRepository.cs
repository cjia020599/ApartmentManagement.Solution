using Property.Domain.Entities;

namespace Property.Domain.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<ApartmentUnit>> GetAllAsync();
        Task AddAsync(ApartmentUnit propertyUnit);
        void DeleteAsync(ApartmentUnit propertyUnit);
        void UpdateAsync(ApartmentUnit propertyUnit);
    }
}
