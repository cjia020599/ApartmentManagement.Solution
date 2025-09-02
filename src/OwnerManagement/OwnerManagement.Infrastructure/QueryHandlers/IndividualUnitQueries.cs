using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OwnerManagement.Application.Queries;
using OwnerManagement.Application.Response;
using OwnerManagement.Domain.ValueObjects;
using OwnerManagement.Infrastructure.Data;

namespace OwnerManagement.Infrastructure.QueryHandlers
{
    public class IndividualUnitQueries : IIndividualUnitQueries
    {
        private readonly OwnerDbContext _context;
        private readonly IMapper _mapper;

        public IndividualUnitQueries(OwnerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public async Task<List<IndividualUnitResponse>> GetAllIndividualUnitsAsync(CancellationToken cancellationToken)
        {
            return await _context.IndividualUnits
                .Select(i => _mapper.Map<IndividualUnitResponse>(i))
                .ToListAsync(cancellationToken);
        }

        public Task<IndividualUnitResponse?> GetIndividualUnitByIdAsync(Guid individualUnitId, CancellationToken cancellationToken)
        {
            return _context.IndividualUnits
                .Where(i => i.Id == new IndividualUnitId(individualUnitId))
                .Select(i => _mapper.Map<IndividualUnitResponse>(i))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
