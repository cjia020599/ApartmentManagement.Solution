using Microsoft.AspNetCore.Mvc;
using TenantAndLeaseManagement.Application.Commands;
using TenantAndLeaseManagement.Application.Queries;
using TenantAndLeaseManagement.Controllers.Request;

namespace TenantAndLeaseManagement.Controllers
{
    [Route("api/tenantandlease")]
    [ApiController]
    public class TenantAndLeaseController : ControllerBase
    {
        private readonly ITenantCommands _tenantCommands;
        private readonly ILeaseCommands _leaseCommands;
        private readonly ITenantQueries _tenantQueries;
        private readonly ILeaseAgreementQueries _leaseQueries;

        public TenantAndLeaseController(ITenantCommands tenantCommands, ILeaseCommands leaseCommands, ITenantQueries tenantQueries, ILeaseAgreementQueries leaseQueries)
        {
            _tenantCommands = tenantCommands;
            _leaseCommands = leaseCommands;
            _tenantQueries = tenantQueries;
            _leaseQueries = leaseQueries;
        }
        [HttpPost("tenant/add")]
        public async Task<IActionResult> AddTenant([FromBody] TenantRequest request)
        {
            var tenant = await _tenantCommands.AddTenantAsync(request.Name, request.Email, request.PhoneNumber, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetTenants), new { id = tenant.Id }, tenant);
        }
        [HttpPost("tenant/update/{id}")]
        public async Task<IActionResult> UpdateTenant(Guid id, [FromBody] TenantRequest request)
        {
            var result = await _tenantCommands.UpdateTenantAsync(id, request.Name, request.Email, request.PhoneNumber, HttpContext.RequestAborted);
            if (result is null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("tenant/delete/{id}")]
        public async Task<IActionResult> DeleteTenant(Guid id)
        {
            var result = await _tenantCommands.DeleteTenantAsync(id, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpGet("tenant/getAll")]
        public async Task<IActionResult> GetTenants(Guid? id)
        {
            var tenant = await _tenantQueries.GetTenantByIdAsync(id);
            return Ok(tenant);
        }
        [HttpPost("lease/create")]
        public async Task<IActionResult> CreateLease([FromBody] CreateLeaseAgreementRequest request)
        {
            var lease = await _leaseCommands.CreateLeaseAsync(request.TenantName, request.OwnerName, request.CreationDate, request.IndividualUnitId, request.MonthlyRent, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetLeases), new { id = lease.Id }, lease);
        }
        [HttpPost("lease/terminate/{id}")]
        public async Task<IActionResult> TermincateLease(Guid id)
        {
            var result = await _leaseCommands.TerminateLeaseAsync(id, HttpContext.RequestAborted);
            if (result is null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPost("lease/renew/{id}")]
        public async Task<IActionResult> RenewLease(Guid id, [FromBody] RenewLeaseAgreement request)
        {
            var result = await _leaseCommands.RenewLeaseAsync(id, request.RenewDate, request.NewMonthlyRent, HttpContext.RequestAborted);
            if (result is null)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpGet("lease/getAll")]
        public async Task<IActionResult> GetLeases(Guid? id)
        {
            var lease = await _leaseQueries.GetLeaseAgreementByIdAsync(id);
            return Ok(lease);
        }
    }
}
