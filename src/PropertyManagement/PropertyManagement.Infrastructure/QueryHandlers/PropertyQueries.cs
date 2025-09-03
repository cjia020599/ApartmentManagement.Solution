using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Application.Queries;
using PropertyManagement.Application.Response;
using PropertyManagement.Infrastructure.Data;

namespace PropertyManagement.Infrastructure.QueryHandlers
{
    public class PropertyQueries : IPropertyQueries
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;

        public PropertyQueries(PropertyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PropertyResponse>> GetAllOccupiedProperties()
        {
            return await _context.Properties
            .Where(p => p.Status == "Occupied")
            .ProjectTo<PropertyResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<List<PropertyResponse>> GetAllPropertiesAsync()
        {
            return await _context.Properties.ProjectTo<PropertyResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<PropertyResponse>> GetAllUnderMaintenanceProperties()
        {
            return await _context.Properties
            .Where(p => p.Status == "Under Maintenance")
            .ProjectTo<PropertyResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<List<PropertyResponse>> GetAllVacantProperties()
        {
            return await _context.Properties
            .Where(p => p.Status == "Vacant")
            .ProjectTo<PropertyResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<PropertyResponse?> GetPropertyByIdAsync(Guid id)
        {
            var property = await _context.Properties.Where(u => u.Id == new Domain.ValueObjects.ApartmentUnitId(id)).FirstOrDefaultAsync();
            if (property == null)
            {
                return null;
            }
            return _mapper.Map<PropertyResponse>(property);
        }
    }
}
