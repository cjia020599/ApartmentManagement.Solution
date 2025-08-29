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
using TenantAndLeaseManagement.Infrastructure.Data;

namespace TenantAndLeaseManagement.Infrastructure.QueryHandlers
{
    public class LeaseAgreementQueries : ILeaseAgreementQueries
    {
        private readonly TenantAndLeaseDbContext _context;
        private readonly IMapper _mapper;

        public LeaseAgreementQueries(TenantAndLeaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<LeaseAgreementResponse>> GetLeaseAgreementByIdAsync(Guid? id)
        {
            var leaseAgreements = id == null
                ? _context.LeaseAgreements
                : _context.LeaseAgreements.Where(l => l.Id == new Domain.ValueObjects.LeaseAgreementId(id.Value));
            return await leaseAgreements.ProjectTo<LeaseAgreementResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
