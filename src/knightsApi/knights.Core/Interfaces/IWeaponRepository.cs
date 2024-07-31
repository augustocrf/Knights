using Knights.Core.Entities;

namespace Knights.Core.Interfaces
{
    public interface IWeaponRepository
    {
        Task<IEnumerable<Weapon>> GetWeaponsAsync();
        Task<IEnumerable<Weapon>> GetWeaponsByFilterAsync(string filter);
        Task<Weapon> GetWeaponByIdAsync(Guid id);
        Task AddWeaponAsync(Weapon weapon);
        Task UpdateWeaponAsync(Weapon weapon);
        Task DeleteWeaponAsync(Guid id);
    }
}