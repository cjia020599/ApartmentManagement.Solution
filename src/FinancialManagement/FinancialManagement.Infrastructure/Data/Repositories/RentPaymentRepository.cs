using FinancialManagement.Domain.Entities;
using FinancialManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialManagement.Infrastructure.Data.Repositories
{
    public class RentPaymentRepository : IRentPaymentRepository
    {
        private readonly FinancialDbContext _context;

        public RentPaymentRepository(FinancialDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(RentPayment rentPayment)
        {
            await _context.RentPayments.AddAsync(rentPayment);
        }

        public async Task<List<RentPayment>> GetAllAsync()
        {
            return await _context.RentPayments.ToListAsync();
        }
    }
}
