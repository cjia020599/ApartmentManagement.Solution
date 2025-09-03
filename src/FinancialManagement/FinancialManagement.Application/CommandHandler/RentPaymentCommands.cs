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
        public async Task<RentPaymentResponse> ProcessRentPaymentAsync(double amount, DateTime paymentDate, Guid tenantId, Guid individualUnitId, Guid ownerId)
        {
            var exists = await _individualUnitRepository.ExistsByIdAsync(individualUnitId, CancellationToken.None);
            if (!exists)
            {
                throw new Exception($"Individual unit with id '{individualUnitId}' does not exist.");
            }
            await _mediator.Publish(new RentPaymentRequestedDomainEvent(ownerId, individualUnitId, tenantId, amount, paymentDate));
            RentPayment rentPayment = RentPayment.Create(amount, paymentDate, tenantId, individualUnitId, ownerId);
            await _unitOfWork.RentPayments.AddAsync(rentPayment);
            await _unitOfWork.SaveChangesAsync(CancellationToken.None);
            return _mapper.Map<RentPaymentResponse>(rentPayment);
        }
    }
}
