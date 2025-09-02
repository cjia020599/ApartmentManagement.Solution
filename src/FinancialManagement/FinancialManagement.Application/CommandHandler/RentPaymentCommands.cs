using AutoMapper;
using FinancialManagement.Application.Commands;
using FinancialManagement.Application.Response;
using FinancialManagement.Domain.Entities;
using FinancialManagement.Domain.Repositories;

namespace FinancialManagement.Application.CommandHandler
{
    public class RentPaymentCommands : IRentPaymentCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RentPaymentCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RentPaymentResponse> ProcessRentPaymentAsync(double amount, DateTime paymentDate, Guid tenantId, Guid buildingId, Guid unitId, Guid ownerId)
        {
            RentPayment rentPayment = RentPayment.Create(amount, paymentDate, tenantId, buildingId, unitId, ownerId);
            await _unitOfWork.RentPayments.AddAsync(rentPayment);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<RentPaymentResponse>(rentPayment);
        }
    }
}
