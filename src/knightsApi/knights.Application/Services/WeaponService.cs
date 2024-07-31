using Knights.Core.Entities;
using Knights.Core.Interfaces;

namespace Knights.Application.Services
{
    public class WeaponService
    {
        private readonly IWeaponRepository _weaponRepository;

        public WeaponService(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public Task<IEnumerable<Weapon>> GetWeaponsAsync() => _weaponRepository.GetWeaponsAsync();

        public Task<IEnumerable<Weapon>> GetWeaponsByFilterAsync(string filter) => _weaponRepository.GetWeaponsByFilterAsync(filter);

        public Task<Weapon> GetWeaponByIdAsync(Guid id) => _weaponRepository.GetWeaponByIdAsync(id);

        public Task AddWeaponAsync(Weapon weapon) => _weaponRepository.AddWeaponAsync(weapon);

        public Task UpdateWeaponAsync(Weapon weapon) => _weaponRepository.UpdateWeaponAsync(weapon);

        public Task DeleteWeaponAsync(Guid id) => _weaponRepository.DeleteWeaponAsync(id);
    }
}