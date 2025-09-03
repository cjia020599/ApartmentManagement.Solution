using Microsoft.AspNetCore.Mvc;
using OwnerManagement.Application.Commands;
using OwnerManagement.Application.Queries;

namespace OwnerManagement.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerCommands _ownerCommands;
        private readonly IIndividualUnitCommands _individualCommands;
        private readonly IOwnerQueries _ownerQueries;
        private readonly IIndividualUnitQueries _individualUnitQueries;

        public OwnerController(IOwnerCommands ownerCommands, IIndividualUnitCommands individualUnitCommands, IOwnerQueries ownerQueries,IIndividualUnitQueries individualUnitQueries)
        {
            _ownerCommands = ownerCommands;
            _individualCommands = individualUnitCommands;   
            _ownerQueries = ownerQueries;
            _individualUnitQueries = individualUnitQueries;
        }
        [HttpPost("addOwner")]
        public async Task<IActionResult> AddOwner(string name)
        {
            var owner = await _ownerCommands.AddOwnerAsync(name, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetOwners), new { id = owner.Id }, owner);
        }
        [HttpPost("addIndividualUnit")]
        public async Task<IActionResult> AddIndividualUnit(string building, string unit)
        {
            var individualUnit = await _individualCommands.AddIndividualUnitAsync(building, unit, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetIndividualUnits), new { id = individualUnit.Id }, individualUnit);
        }
        [HttpDelete("deleteOwner")]
        public async Task<IActionResult> DeleteOwner(Guid ownerId)
        {
            var result = await _ownerCommands.DeleteOwnerAsync(ownerId, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpDelete("deleteIndividualUnit")]
        public async Task<IActionResult> DeleteIndividualUnit(Guid individualUnitId)
        {
            var result = await _individualCommands.DeleteIndividualUnitAsync(individualUnitId, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpGet("getAllOwners")]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _ownerQueries.GetAllOwnersAsync(HttpContext.RequestAborted);
            return Ok(owners);
        }
        [HttpGet("getAllIndividualUnits")]
        public async Task<IActionResult> GetIndividualUnits()
        {
            var individualUnits = await _individualUnitQueries.GetAllIndividualUnitsAsync(HttpContext.RequestAborted);
            return Ok(individualUnits);
        }
        [HttpPost("assignUnitToOwner")]
        public async Task<IActionResult> AssignUnitToOwner(Guid ownerId, Guid individualUnitId)
        {
            var result = await _ownerCommands.AssignUnitToOwnerAsync(ownerId, individualUnitId, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpPost("removeUnitToOwner")]
        public async Task<IActionResult> RemoveUnitToOwner(Guid ownerId, Guid individualUnitId)
        {
            var result = await _ownerCommands.RemoveUnitFromOwnerAsync(ownerId, individualUnitId, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpPost("updateOwner")]
        public async Task<IActionResult> UpdateOwner(Guid ownerId, string name)
        {
            var result = await _ownerCommands.UpdateOwnerAsync(ownerId, name, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpPost("updateIndividualUnit")]
        public async Task<IActionResult> UpdateIndividualUnit(Guid individualUnitId, string building, string unit)
        {
            var result = await _individualCommands.UpdateIndividualUnitAsync(individualUnitId, building, unit, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
    }
}
