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
        [HttpPost("rentPayments")]
        public async Task<IActionResult> CreateRentPayment(double amount, DateTime paymentDate, Guid tenantId, Guid individualUnitId, Guid ownerId)
        {
            var rentPayment = await _commands.ProcessRentPaymentAsync(amount, paymentDate, tenantId, individualUnitId, ownerId);
            return CreatedAtAction(nameof(GetRentPaymentById), new { id = rentPayment.Id }, rentPayment);
        }
        [HttpGet("rentPayments")]
        public async Task<IActionResult> GetRentPayments()
        {
            var rentPayments = await _queries.GetAllRentPaymentsAsync();
            return Ok(rentPayments);
        }
        [HttpGet("rentPayments/{id}")]
        public async Task<IActionResult> GetRentPaymentById(Guid id)
        {
            var rentPayment = await _queries.GetRentPaymentByIdAsync(id);
            if (rentPayment is null)
            {
                return NotFound();
            }
            return Ok(rentPayment);
        }
    }
}
