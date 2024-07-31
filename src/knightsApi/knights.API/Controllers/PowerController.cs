using Knights.Application.Services;
using Knights.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Knights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly PowerService _powerService;

        public PowerController(PowerService powerService)
        {
            _powerService = powerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPowers([FromQuery] string? filter)
        {
            var powers = filter == null
                ? await _powerService.GetPowersAsync()
                : await _powerService.GetPowersByFilterAsync(filter);
            return Ok(powers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPowerById(Guid id)
        {
            var power = await _powerService.GetPowerByIdAsync(id);
            if (power == null) return NotFound();
            return Ok(power);
        }

        [HttpPost]
        public async Task<IActionResult> AddPower([FromBody] Power power)
        {
            await _powerService.AddPowerAsync(power);
            return CreatedAtAction(nameof(GetPowerById), new { id = power.Id }, power);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePower(Guid id, [FromBody] Power power)
        {
            power.Id = id;
            await _powerService.UpdatePowerAsync(power);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePower(Guid id)
        {
            await _powerService.DeletePowerAsync(id);
            return NoContent();
        }
    }
}