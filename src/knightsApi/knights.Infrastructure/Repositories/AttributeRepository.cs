using Knights.Core.Entities;
using Knights.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Knights.Infrastructure.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly IMongoCollection<Attributes> _attributesCollection;

        public AttributeRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _attributesCollection = database.GetCollection<Attributes>("Attributes");
        }

        public async Task<IEnumerable<Attributes>> GetAttributesAsync()
        {
            return await _attributesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Attributes> GetAttributeByIdAsync(Guid id)
        {
            return await _attributesCollection.Find(k => k.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAttributeAsync(Attributes attribute)
        {
            attribute.Id = Guid.NewGuid();
            await _attributesCollection.InsertOneAsync(attribute);
        }

        public async Task UpdateAttributeAsync(Attributes attribute)
        {
            await _attributesCollection.ReplaceOneAsync(k => k.Id == attribute.Id, attribute);
        }

        public async Task DeleteAttributeAsync(Guid id)
        {
            await _attributesCollection.DeleteOneAsync(k => k.Id == id);
        }
    }
}