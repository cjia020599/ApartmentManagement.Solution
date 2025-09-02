using AutoMapper;
using FluentResults;
using OwnerManagement.Application.Commands;
using OwnerManagement.Application.Response;
using OwnerManagement.Domain.Entities;
using OwnerManagement.Domain.Repositories;
using OwnerManagement.Domain.ValueObjects;

namespace OwnerManagement.Application.CommandHandler
{
    public class OwnerCommands : IOwnerCommands
    {
        private readonly IMapper _mapper;
        private readonly IUnitOFWork _unitOfWork;

        public OwnerCommands(IMapper mapper, IUnitOFWork unitOFWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOFWork;
        }

        public async Task<OwnerResponse> AddOwnerAsync(string name, CancellationToken cancellationToken)
        {
            Owner owner = Owner.Create(name, []);
            await _unitOfWork.Owners.AddAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OwnerResponse>(owner);

        }

        public async Task<Result> AssignUnitToOwnerAsync(Guid ownerId, string building, string unit, CancellationToken cancellationToken)
        {
            List<Owner> owners = _unitOfWork.Owners.GetAllAsync().Result;
            Owner? owner = owners.FirstOrDefault(o => o.Id == new OwnerId(ownerId));
            if (owner == null)
            {
                throw new Exception("This owner doesn't exist.");
            }
            List<IndividualUnit> individualUnits = _unitOfWork.IndividualUnits.GetAllAsync().Result;
            IndividualUnit? individualUnit = individualUnits.FirstOrDefault(i => i.Building == building && i.Unit == unit);
            if (individualUnit == null)
            {
                throw new Exception("This individual unit doesn't exist.");
            }
            var updatedOwner = owner.AddIndividualUnit(owner,individualUnit);
            _unitOfWork.Owners.UpdateAsync(updatedOwner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> DeleteOwnerAsync(Guid ownerId, CancellationToken cancellationToken)
        {
            List<Owner> owners = _unitOfWork.Owners.GetAllAsync().Result;
            Owner? owner = owners.FirstOrDefault(o => o.Id == new OwnerId(ownerId));
            if (owner == null)
            {
                throw new Exception("This owner doesn't exist.");
            }
            _unitOfWork.Owners.DeleteAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();

        }

        public async Task<Result> RemoveUnitFromOwnerAsync(Guid ownerId, string building, string unit, CancellationToken cancellationToken)
        {
            List<Owner> owners = _unitOfWork.Owners.GetAllAsync().Result;
            Owner? owner = owners.FirstOrDefault(o => o.Id == new OwnerId(ownerId));
            if (owner == null)
            {
                throw new Exception("This owner doesn't exist.");
            }
            List<IndividualUnit> individualUnits = _unitOfWork.IndividualUnits.GetAllAsync().Result;
            IndividualUnit? individualUnit = individualUnits.FirstOrDefault(i => i.Building == building && i.Unit == unit);
            if (individualUnit == null)
            {
                throw new Exception("This individual unit doesn't exist.");
            }
            var updatedOwner = owner.RemoveIndividualUnit(owner, individualUnit);
            _unitOfWork.Owners.UpdateAsync(updatedOwner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> UpdateOwnerAsync(Guid ownerId, string name, CancellationToken cancellationToken)
        {
           List<Owner> owners = _unitOfWork.Owners.GetAllAsync().Result;
            Owner? owner = owners.FirstOrDefault(o => o.Id == new OwnerId(ownerId));
            if (owner == null)
            {
                throw new Exception("This owner doesn't exist.");
            }
            owner.Update(name, owner.IndividualUnits);
            _unitOfWork.Owners.UpdateAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
