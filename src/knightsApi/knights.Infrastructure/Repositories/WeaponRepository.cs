using Knights.Core.Entities;
using Knights.Core.Interfaces;
using System.Collections.Concurrent;

namespace Knights.Infrastructure.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private static ConcurrentDictionary<Guid, Weapon> _weapons = new();

        public Task<IEnumerable<Weapon>> GetWeaponsAsync() => Task.FromResult(_weapons.Values.AsEnumerable());

        public Task<IEnumerable<Weapon>> GetWeaponsByFilterAsync(string filter) => 
            Task.FromResult(_weapons.Values.Where(w => w.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).AsEnumerable());

        public Task<Weapon> GetWeaponByIdAsync(Guid id) =>
            _weapons.TryGetValue(id, out var weapon) ? Task.FromResult(weapon) : Task.FromResult<Weapon>(null);

        public Task AddWeaponAsync(Weapon weapon)
        {
            weapon.Id = Guid.NewGuid();
            _weapons[weapon.Id] = weapon;
            return Task.CompletedTask;
        }

        public Task UpdateWeaponAsync(Weapon weapon)
        {
            _weapons[weapon.Id] = weapon;
            return Task.CompletedTask;
        }

        public Task DeleteWeaponAsync(Guid id)
        {
            _weapons.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}