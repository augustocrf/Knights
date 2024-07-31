using Knights.Application.Services;
using Knights.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Knights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly AttributeService _attributeService;

        public AttributeController(AttributeService attributeService)
        {
            _attributeService = attributeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAttributes()
        {
            var attributes = await _attributeService.GetAttributesAsync();
            return Ok(attributes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttributeById(Guid id)
        {
            var attribute = await _attributeService.GetAttributeByIdAsync(id);
            if (attribute == null) return NotFound();
            return Ok(attribute);
        }

        [HttpPost]
        public async Task<IActionResult> AddAttribute([FromBody] Attributes attribute)
        {
            await _attributeService.AddAttributeAsync(attribute);
            return CreatedAtAction(nameof(GetAttributeById), new { id = attribute.Id }, attribute);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttribute(Guid id, [FromBody] Attributes attribute)
        {
            attribute.Id = id;
            await _attributeService.UpdateAttributeAsync(attribute);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(Guid id)
        {
            await _attributeService.DeleteAttributeAsync(id);
            return NoContent();
        }
    }
}