using AutoMapper;
using FinancialManagement.Application.Queries;
using FinancialManagement.Application.Response;
using FinancialManagement.Domain.ValueObjects;
using FinancialManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Infrastructure.QueryHandlers
{
    public class RentPaymentQueries : IRentPaymentQueries
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public RentPaymentQueries(FinancialDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RentPaymentResponse>> GetAllRentPaymentsAsync()
        {
            return await _context.RentPayments
                .Select(rp => _mapper.Map<RentPaymentResponse>(rp))
                .ToListAsync();
        }

        public async Task<RentPaymentResponse?> GetRentPaymentByIdAsync(Guid id)
        {
            return await _context.RentPayments
                .Where(rp => rp.Id == new RentPaymentId(id))
                .Select(rp => _mapper.Map<RentPaymentResponse>(rp))
                .FirstOrDefaultAsync();
        }

        public async Task<List<RentPaymentResponse>> GetRentPaymentsByBuildingAsync(string building)
        {
            return await _context.RentPayments
                .Where(rp => rp.Building == building)
                .Select(rp => _mapper.Map<RentPaymentResponse>(rp))
                .ToListAsync();
        }

        public async Task<List<RentPaymentResponse>> GetRentPaymentsByOwnerAsync(Guid ownerId)
        {
            return await _context.RentPayments
                .Where(rp => rp.OwnerId == ownerId)
                .Select(rp => _mapper.Map<RentPaymentResponse>(rp))
                .ToListAsync(); 
        }

        public async Task<List<RentPaymentResponse>> GetRentPaymentsByTenantAsync(Guid tenantId)
        {
            return await _context.RentPayments
                .Where(rp => rp.TenantId == tenantId)
                .Select(rp => _mapper.Map<RentPaymentResponse>(rp))
                .ToListAsync();
        }

        public Task<List<RentPaymentResponse>> GetRentPaymentsByUnitAsync(string unit)
        {
            return _context.RentPayments
                .Where(rp => rp.Unit == unit)
                .Select(rp => _mapper.Map<RentPaymentResponse>(rp))
                .ToListAsync();
        }
    }
}
