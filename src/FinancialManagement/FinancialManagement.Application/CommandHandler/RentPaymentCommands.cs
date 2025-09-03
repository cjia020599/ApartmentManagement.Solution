using AutoMapper;
using FinancialManagement.Application.Commands;
using FinancialManagement.Application.Response;
using FinancialManagement.Domain.Entities;
using FinancialManagement.Domain.Repositories;
using FinancialManagement.Domain.Events;
using MediatR;
using OwnerManagement.Domain.Repositories;
using FluentResults;

namespace FinancialManagement.Application.CommandHandler
{
    public class RentPaymentCommands : IRentPaymentCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IIndividualUnitRepository _individualUnitRepository;

        public RentPaymentCommands(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator, IIndividualUnitRepository individualUnitRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
            _individualUnitRepository = individualUnitRepository;
        }
        public async Task<RentPaymentResponse> ProcessRentPaymentAsync(double amount, DateTime paymentDate, Guid tenantId, string building, string unit, Guid ownerId)
        {
            var individualUnits = await _individualUnitRepository.GetAllAsync();
            var exists = individualUnits.Any(iu => iu.Building == building && iu.Unit == unit);
            if (!exists)
            {
                throw new Exception($"Unit '{unit}' in building '{building}' does not exist.");
            }
            await _mediator.Publish(new RentPaymentRequestedDomainEvent(ownerId, building, unit, tenantId, amount, paymentDate));
            RentPayment rentPayment = RentPayment.Create(amount, paymentDate, tenantId, building, unit, ownerId);
            await _unitOfWork.RentPayments.AddAsync(rentPayment);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<RentPaymentResponse>(rentPayment);
        }
    }
}
