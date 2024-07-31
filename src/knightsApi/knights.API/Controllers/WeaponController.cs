using System.Net;
using Knights.Application.Services;
using Knights.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Knights.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly WeaponService _weaponService;

        public WeaponController(WeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeapons([FromQuery] string? filter)
        {
            var weapons = filter == null
                ? await _weaponService.GetWeaponsAsync()
                : await _weaponService.GetWeaponsByFilterAsync(filter);
            return Ok(weapons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeaponById(Guid id)
        {
            var weapon = await _weaponService.GetWeaponByIdAsync(id);
            if (weapon == null) return NotFound();
            return Ok(weapon);
        }

        [HttpPost]
        public async Task<IActionResult> AddWeapon([FromBody] Weapon weapon)
        {
            await _weaponService.AddWeaponAsync(weapon);
            return CreatedAtAction(nameof(GetWeaponById), new { id = weapon.Id }, weapon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeapon(Guid id, [FromBody] Weapon weapon)
        {
            weapon.Id = id;
            await _weaponService.UpdateWeaponAsync(weapon);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon(Guid id)
        {
            await _weaponService.DeleteWeaponAsync(id);
            return NoContent();
        }
    }
}