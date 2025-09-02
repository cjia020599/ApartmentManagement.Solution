using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OwnerManagement.Application.Queries;
using OwnerManagement.Application.Response;
using OwnerManagement.Infrastructure.Data;

namespace OwnerManagement.Infrastructure.QueryHandlers
{
    public class OwnerQueries : IOwnerQueries
    {
        private readonly OwnerDbContext _context;
        private readonly IMapper _mapper;

        public OwnerQueries(OwnerDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;   
        }
        public async Task<List<OwnerResponse>> GetAllOwnersAsync(CancellationToken cancellationToken)
        {
           var items = await _context.Owners.Include(b => b.IndividualUnits)
                .Select(o => _mapper.Map<OwnerResponse>(o))
                .ToListAsync();
            return items;
        }
    }
}
