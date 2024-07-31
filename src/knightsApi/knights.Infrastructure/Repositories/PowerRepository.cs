using Knights.Core.Entities;
using Knights.Core.Interfaces;
using System.Collections.Concurrent;

namespace Knights.Infrastructure.Repositories
{
    public class PowerRepository : IPowerRepository
    {
        private static ConcurrentDictionary<Guid, Power> _powers = new();

        public Task<IEnumerable<Power>> GetPowersAsync() => Task.FromResult(_powers.Values.AsEnumerable());

        public Task<IEnumerable<Power>> GetPowersByFilterAsync(string filter) => 
            Task.FromResult(_powers.Values.Where(p => p.Description.Contains(filter, StringComparison.OrdinalIgnoreCase)).AsEnumerable());

        public Task<Power> GetPowerByIdAsync(Guid id) =>
            _powers.TryGetValue(id, out var power) ? Task.FromResult(power) : Task.FromResult<Power>(null);

        public Task AddPowerAsync(Power power)
        {
            power.Id = Guid.NewGuid();
            _powers[power.Id] = power;
            return Task.CompletedTask;
        }

        public Task UpdatePowerAsync(Power power)
        {
            _powers[power.Id] = power;
            return Task.CompletedTask;
        }

        public Task DeletePowerAsync(Guid id)
        {
            _powers.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}