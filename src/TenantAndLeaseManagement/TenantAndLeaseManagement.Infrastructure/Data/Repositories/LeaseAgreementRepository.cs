using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.Repositories;
using TenantAndLeaseManagement.Domain.Services;

namespace TenantAndLeaseManagement.Infrastructure.Data.Repositories
{
    public class LeaseAgreementRepository : ILeaseAgreementRepository
    {
        private readonly TenantAndLeaseDbContext _context;

        public LeaseAgreementRepository(TenantAndLeaseDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(LeaseAgreement leaseAgreement)
        {
            await _context.LeaseAgreements.AddAsync(leaseAgreement);
        }

        public async Task<List<LeaseAgreement>> GetAllAsync()
        {
            return await _context.LeaseAgreements.ToListAsync();
        }

        public void RenewAsync(LeaseAgreement leaseAgreement)
        {
            _context.LeaseAgreements.Update(leaseAgreement);
        }

        public void TerminateAsync(LeaseAgreement leaseAgreement)
        {
            _context.LeaseAgreements.Update(leaseAgreement);
        }
    }
}
