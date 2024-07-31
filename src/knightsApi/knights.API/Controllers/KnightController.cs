using Knights.Application.Services;
using Knights.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Knights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnightController : ControllerBase
    {
        private readonly KnightService _knightService;

        public KnightController(KnightService knightService)
        {
            _knightService = knightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetKnights([FromQuery] string? filter)
        {
            var knights = filter == null
                ? await _knightService.GetKnightsAsync()
                : await _knightService.GetKnightsByFilterAsync(filter);
            return Ok(knights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKnightById(Guid id)
        {
            var knight = await _knightService.GetKnightByIdAsync(id);
            if (knight == null) return NotFound();
            return Ok(knight);
        }

        [HttpPost]
        public async Task<IActionResult> AddKnight([FromBody] Knight knight)
        {
            await _knightService.AddKnightAsync(knight);
            return CreatedAtAction(nameof(GetKnightById), new { id = knight.Id }, knight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKnight(Guid id, [FromBody] Knight knight)
        {
            knight.Id = id;
            await _knightService.UpdateKnightAsync(knight);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnight(Guid id)
        {
            await _knightService.DeleteKnightAsync(id);
            return NoContent();
        }
    }
}