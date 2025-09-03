using AutoMapper;
using FluentResults;
using OwnerManagement.Application.Commands;
using OwnerManagement.Application.Response;
using OwnerManagement.Domain.Entities;
using OwnerManagement.Domain.Repositories;
using OwnerManagement.Domain.ValueObjects;
using MediatR;
using OwnerManagement.Domain.Events;

namespace OwnerManagement.Application.CommandHandler
{
    public class IndividualUnitCommands : IIndividualUnitCommands
    {
        private readonly IMapper _mapper;
        private readonly IUnitOFWork _unitOfWork;
        private readonly IMediator _mediator;

        public IndividualUnitCommands(IMapper mapper, IUnitOFWork unitofWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitofWork;
            _mediator = mediator;
        }
        public async Task<IndividualUnitResponse> AddIndividualUnitAsync(string building, string unit, CancellationToken cancellationToken)
        {
            IndividualUnit individualUnit = IndividualUnit.Create(unit,building);
            await _unitOfWork.IndividualUnits.AddAsync(individualUnit);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new IndividualUnitCreated(individualUnit.Id.Value, building, unit), cancellationToken);
            return _mapper.Map<IndividualUnitResponse>(individualUnit);
        }

        public async Task<Result> DeleteIndividualUnitAsync(Guid individualUnitId, CancellationToken cancellationToken)
        {
            List<IndividualUnit> individualUnits =  _unitOfWork.IndividualUnits.GetAllAsync().Result;
            IndividualUnit? individualUnit = individualUnits.FirstOrDefault(i => i.Id == new IndividualUnitId(individualUnitId));
            if (individualUnit == null)
            {
                throw new Exception("This individual unit doesn't exist.");
            }
            _unitOfWork.IndividualUnits.DeleteAsync(individualUnit);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new IndividualUnitDeleted(individualUnit.Id.Value), cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> UpdateIndividualUnitAsync(Guid individualUnitId, string building, string unit, CancellationToken cancellationToken)
        {
            List<IndividualUnit> individualUnits = _unitOfWork.IndividualUnits.GetAllAsync().Result;
            IndividualUnit? individualUnit = individualUnits.FirstOrDefault(i => i.Id == new IndividualUnitId(individualUnitId));
            if (individualUnit == null)
            {
                throw new Exception("This individual unit doesn't exist.");
            }
            individualUnit.Update(unit, building);
            _unitOfWork.IndividualUnits.UpdateAsync(individualUnit);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _mediator.Publish(new IndividualUnitUpdated(individualUnit.Id.Value, building, unit), cancellationToken);
            return Result.Ok();
        }
    }
}
