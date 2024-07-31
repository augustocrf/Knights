using Knights.Core.Entities;
using Knights.Core.Interfaces;

namespace Knights.Application.Services
{
    public class KnightService
    {
        private readonly IKnightRepository _knightRepository;

        public KnightService(IKnightRepository knightRepository)
        {
            _knightRepository = knightRepository;
        }

        public Task<IEnumerable<Knight>> GetKnightsAsync() => _knightRepository.GetKnightsAsync();

        public Task<IEnumerable<Knight>> GetKnightsByFilterAsync(string filter) => _knightRepository.GetKnightsByFilterAsync(filter);

        public Task<Knight> GetKnightByIdAsync(Guid id) => _knightRepository.GetKnightByIdAsync(id);

        public Task AddKnightAsync(Knight knight) => _knightRepository.AddKnightAsync(knight);

        public Task UpdateKnightAsync(Knight knight) => _knightRepository.UpdateKnightAsync(knight);

        public Task DeleteKnightAsync(Guid id) => _knightRepository.DeleteKnightAsync(id);
    }
}