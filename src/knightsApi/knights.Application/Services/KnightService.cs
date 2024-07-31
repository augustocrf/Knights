using Knights.Core.Entities;
using Knights.Core.Interfaces;
using Knights.Core.Helpers.Utils;

namespace Knights.Application.Services
{
    public class KnightService
    {
        private readonly IKnightRepository _knightRepository;

        public KnightService(IKnightRepository knightRepository)
        {
            _knightRepository = knightRepository;
        }

        public async Task<IEnumerable<Knight>> GetKnightsAsync() {
            var knights = await _knightRepository.GetKnightsAsync();

            return GetKnight(knights);
        }

        public async Task<IEnumerable<Knight>> GetKnightsByFilterAsync(string filter) {
            var knights = await _knightRepository.GetKnightsByFilterAsync(filter);
            
            return GetKnight(knights);
        }

        public async Task<Knight> GetKnightByIdAsync(Guid id) {
            Knight knight = await _knightRepository.GetKnightByIdAsync(id);
            knight.Age = CalculateAge(knight);
            knight.Attack = CalculateAttack(knight);
            knight.Exp = CalculateExperience(knight);

            return knight;
        }
        
        public Task AddKnightAsync(Knight knight) => _knightRepository.AddKnightAsync(knight);

        public Task UpdateKnightAsync(Knight knight) => _knightRepository.UpdateKnightAsync(knight);

        public Task DeleteKnightAsync(Guid id) => _knightRepository.DeleteKnightAsync(id);

        private int CalculateAge(Knight knight)
        {
            var today = DateTime.Today;
            var age = today.Year - knight.Birthday.Year;
            if (knight.Birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        private int CalculateAttack(Knight knight)
        {
            const int baseAttack = 10;
            var keyAttrValue = knight.Attribute.Strength;
            var keyAttrMod = AttributeModifier.GetModifier(keyAttrValue);
            var equippedWeaponMod = knight.Weapons.Any(w => w.Equipped) ? knight.Weapons.First(w => w.Equipped).Mod : 0;
            return baseAttack + keyAttrMod + equippedWeaponMod;
        }

        private int CalculateExperience(Knight knight)
        {
            int age = CalculateAge(knight);
            if (age < 7)
                return 0;

            return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45));
        }

        private IEnumerable<Knight> GetKnight(IEnumerable<Knight> knights){
            return knights.Select(knight => new Knight
            {
                Id = knight.Id,
                Name = knight.Name,
                HeroClass = knight.HeroClass,
                Powers = knight.Powers,
                Weapons = knight.Weapons,
                Attribute = knight.Attribute,
                Age = CalculateAge(knight),
                Attack = CalculateAttack(knight),
                Exp = CalculateExperience(knight)
            }).ToList();
        }
    }
}