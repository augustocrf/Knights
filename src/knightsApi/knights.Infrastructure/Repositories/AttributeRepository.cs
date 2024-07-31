using Knights.Core.Entities;
using Knights.Core.Interfaces;
using System.Collections.Concurrent;

namespace Knights.Infrastructure.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private static ConcurrentDictionary<Guid, Attributes> _attributes = new();
        public Task<IEnumerable<Attributes>> GetAttributesAsync() => Task.FromResult(_attributes.Values.AsEnumerable());
        public Task<Attributes> GetAttributeByIdAsync(Guid id) =>
            _attributes.TryGetValue(id, out var attribute) ? Task.FromResult(attribute) : Task.FromResult<Attributes>(null);
        public Task AddAttributeAsync(Attributes attribute)
        {
            attribute.Id = Guid.NewGuid();
            _attributes[attribute.Id] = attribute;
            return Task.CompletedTask;
        }

        public Task UpdateAttributeAsync(Attributes attribute)
        {
            _attributes[attribute.Id] = attribute;
            return Task.CompletedTask;
        }

        public Task DeleteAttributeAsync(Guid id)
        {
            _attributes.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}