using AutoMapper;
using TenantAndLeaseManagement.Application.Commands;
using TenantAndLeaseManagement.Application.Response;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.Repositories;
using TenantAndLeaseManagement.Domain.ValueObjects;

namespace TenantAndLeaseManagement.Application.CommandHandler
{
    public class LeaseCommands : ILeaseCommands
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LeaseCommands(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<LeaseAgreementResponse> CreateLeaseAsync(string tenantName, string ownerName, DateTime creationDate, DateTime terminationDate, string building, string unit, decimal monthlyRent, CancellationToken cancellationToken)
        {
            LeaseAgreement agreement = LeaseAgreement.Create(tenantName, ownerName, creationDate, terminationDate, building, unit, monthlyRent);
            await _unitOfWork.LeaseAgreements.CreateAsync(agreement);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<LeaseAgreementResponse>(agreement);
        }

        public Task<LeaseAgreementResponse> RenewLeaseAsync(Guid leaseId, DateTime newTerminationDate, decimal newMonthlyRent, CancellationToken cancellationToken)
        {
            List<LeaseAgreement> leases = _unitOfWork.LeaseAgreements.GetAllAsync().Result;
            LeaseAgreement? lease = leases.FirstOrDefault(l => l.Id == new LeaseAgreementId(leaseId));
            if (lease == null)
            {
                return Task.FromResult<LeaseAgreementResponse>(result: null);
            }
            LeaseAgreement renewedLease = LeaseAgreement.Renew(lease, newTerminationDate, newMonthlyRent);
            _unitOfWork.LeaseAgreements.RenewAsync(renewedLease);
            _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task.FromResult(_mapper.Map<LeaseAgreementResponse>(renewedLease));
        }

        public Task<LeaseAgreementResponse> TerminateLeaseAsync(Guid leaseId, CancellationToken cancellationToken)
        {
            List<LeaseAgreement> leases = _unitOfWork.LeaseAgreements.GetAllAsync().Result;
            LeaseAgreement? lease = leases.FirstOrDefault(l => l.Id == new LeaseAgreementId(leaseId));
            if (lease == null)
            {
                return Task.FromResult<LeaseAgreementResponse>(result: null);
            }
            LeaseAgreement terminatedLease = LeaseAgreement.Terminate(lease);
            _unitOfWork.LeaseAgreements.TerminateAsync(terminatedLease);
            _unitOfWork.SaveChangesAsync(cancellationToken);
            return Task.FromResult(_mapper.Map<LeaseAgreementResponse>(terminatedLease));
        }
    }
}
