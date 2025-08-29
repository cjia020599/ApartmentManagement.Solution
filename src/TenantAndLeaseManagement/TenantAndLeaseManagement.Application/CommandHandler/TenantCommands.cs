using AutoMapper;
using FluentResults;
using TenantAndLeaseManagement.Application.Commands;
using TenantAndLeaseManagement.Application.Errors;
using TenantAndLeaseManagement.Application.Response;
using TenantAndLeaseManagement.Domain.Entities;
using TenantAndLeaseManagement.Domain.Repositories;
using TenantAndLeaseManagement.Domain.ValueObjects;

namespace TenantAndLeaseManagement.Application.CommandHandler
{
    public class TenantCommands : ITenantCommands
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TenantCommands(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<TenantResponse> AddTenantAsync(string name, string email, string phoneNumber, CancellationToken cancellationToken)
        {
           Tenant tenant = Tenant.Create(name, email, phoneNumber);
           await _unitOfWork.Tenants.AddAsync(tenant);
           await _unitOfWork.SaveChangesAsync(cancellationToken);
           return _mapper.Map<TenantResponse>(tenant);
        }

        public async Task<Result> DeleteTenantAsync(Guid id, CancellationToken cancellationToken)
        {
            List<Tenant> tenants = await _unitOfWork.Tenants.GetAllAsync();
            Tenant? tenant = tenants.FirstOrDefault(t => t.Id == new TenantId(id));
            if (tenant == null)
            {
                return Result.Fail(new TenantNotExistingError("Tenant not found."));
            }

            Tenant.Delete(tenant);
            _unitOfWork.Tenants.DeleteAsync(tenant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<TenantResponse?> UpdateTenantAsync(Guid id, string name, string email, string phoneNumber, CancellationToken cancellationToken)
        {
            List<Tenant> tenants =  _unitOfWork.Tenants.GetAllAsync().Result;
            Tenant? tenant = tenants.FirstOrDefault(t => t.Id == new TenantId(id));
            if (tenant == null)
            {
                return await Task.FromResult<TenantResponse?>(result: null);
            }
            Tenant.Update(tenant,name, email, phoneNumber);
            _unitOfWork.Tenants.UpdateAsync(tenant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TenantResponse?>(tenant);
        }
    }
}
