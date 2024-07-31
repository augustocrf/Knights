using Knights.Core.Entities;
using Knights.Core.Interfaces;
using System.Collections.Concurrent;

namespace Knights.Infrastructure.Repositories
{
    public class KnightRepository : IKnightRepository
    {
        private static ConcurrentDictionary<Guid, Knight> _knights = new();

        public Task<IEnumerable<Knight>> GetKnightsAsync() => Task.FromResult(_knights.Values.AsEnumerable());

        public Task<IEnumerable<Knight>> GetKnightsByFilterAsync(string filter) => 
            Task.FromResult(_knights.Values.Where(k => k.HeroClass.Contains(filter, StringComparison.OrdinalIgnoreCase)).AsEnumerable());

        public Task<Knight> GetKnightByIdAsync(Guid id) =>
            _knights.TryGetValue(id, out var knight) ? Task.FromResult(knight) : Task.FromResult<Knight>(null);

        public Task AddKnightAsync(Knight knight)
        {
            knight.Id = Guid.NewGuid();
            _knights[knight.Id] = knight;
            return Task.CompletedTask;
        }

        public Task UpdateKnightAsync(Knight knight)
        {
            _knights[knight.Id] = knight;
            return Task.CompletedTask;
        }

        public Task DeleteKnightAsync(Guid id)
        {
            _knights.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}