using FinancialManagement.Application.Commands;
using FinancialManagement.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManagement.Controllers
{
    [Route("api/financial")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        private readonly IRentPaymentCommands _commands;
        private readonly IRentPaymentQueries _queries;

        public FinancialController(IRentPaymentCommands commands, IRentPaymentQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }
        [HttpPost("createRentPayment")]
        public async Task<IActionResult> CreateRentPayment(double amount, DateTime paymentDate, Guid tenantId, Guid buildingId, Guid unitId, Guid ownerId)
        {
            var rentPayment = await _commands.ProcessRentPaymentAsync(amount, paymentDate, tenantId, buildingId, unitId, ownerId);
            return CreatedAtAction(nameof(GetRentPayments), new { id = rentPayment.Id }, rentPayment);
        }
        [HttpGet("getRentPayments")]
        public async Task<IActionResult> GetRentPayments()
        {
            var rentPayments = await _queries.GetAllRentPaymentsAsync();
            return Ok(rentPayments);
        }
    }
}
