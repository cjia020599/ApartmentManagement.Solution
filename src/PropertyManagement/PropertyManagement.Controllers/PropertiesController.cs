using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Application.Commands;
using PropertyManagement.Application.Queries;
using PropertyManagement.Application.Response;
using PropertyManagement.Controllers.Request;

namespace PropertyManagement.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyCommands _commands;
        private readonly IPropertyQueries _queries;

        public PropertiesController(IPropertyCommands commands, IPropertyQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProperty([FromBody] AddPropertyRequest request)
        {
            PropertyResponse property = await _commands.AddPropertyAsync(request.Unit, request.Building, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property.Id }, property);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            var result = await _commands.DeletePropertyAsync(id, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetProperties(Guid? id)
        {
            if (id.HasValue)
            {
                var property = await _queries.GetPropertyByIdAsync(id.Value);
                if (property == null) return NotFound();
                return Ok(property);
            }
            var properties = await _queries.GetAllPropertiesAsync();
            return Ok(properties);
        }
        [HttpGet("getAllVacants")]
        public async Task<IActionResult> GetVacantProperties()
        {
            List<PropertyResponse> property = await _queries.GetAllVacantProperties();
            return Ok(property);
        }
        [HttpGet("getAllOccupied")]
        public async Task<IActionResult> GetOccupiedProperties()
        {
            List<PropertyResponse> property = await _queries.GetAllOccupiedProperties();
            return Ok(property);
        }
        [HttpGet("getAllUnderMaintenance")]
        public async Task<IActionResult> GetUnderMaintenanceProperties()
        {
            List<PropertyResponse> property = await _queries.GetAllUnderMaintenanceProperties();
            return Ok(property);
        }
        [HttpPost("vacantUnit")]
        public async Task<IActionResult> VacantUnit(Guid propertyId)
        {
            var property = await _commands.VacantPropertyAsync(propertyId, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property }, property);
        }
        [HttpPost("occupyUnit")]
        public async Task<IActionResult> OccupyUnit(Guid propertyId)
        {
            var property = await _commands.OccupyPropertyAsync(propertyId, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property }, property);
        }
        [HttpPost("underMaintenanceUnit")]
        public async Task<IActionResult> UnderMaintainanceUnit(Guid propertyId)
        {
            var property = await _commands.UnderMaintenancePropertyAsync(propertyId, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property }, property);
        }
    }
}
