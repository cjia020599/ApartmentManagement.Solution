using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantAndLeaseManagement.Application.Queries;
using TenantAndLeaseManagement.Application.Response;
using TenantAndLeaseManagement.Domain.ValueObjects;
using TenantAndLeaseManagement.Infrastructure.Data;

namespace TenantAndLeaseManagement.Infrastructure.QueryHandlers
{
    public class TenantQueries : ITenantQueries
    {
        private readonly TenantAndLeaseDbContext _context;
        private readonly IMapper _mapper;

        public TenantQueries(TenantAndLeaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TenantResponse>> GetTenantByIdAsync(Guid? id)
        {
            var tenants = id == null
                ? _context.Tenants
                : _context.Tenants.Where(t => t.Id == new TenantId(id.Value));

            return await tenants
                .ProjectTo<TenantResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}
