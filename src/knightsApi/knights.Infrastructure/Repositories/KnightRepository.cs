using Knights.Core.Entities;
using Knights.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Knights.Infrastructure.Repositories
{
    public class KnightRepository : IKnightRepository
    {
        private readonly IMongoCollection<Knight> _knightsCollection;

        public KnightRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _knightsCollection = database.GetCollection<Knight>("Knights");
        }

        public async Task<IEnumerable<Knight>> GetKnightsAsync()
        {
            return await _knightsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Knight>> GetKnightsByFilterAsync(string filter)
        {
            var filterDefinition = Builders<Knight>.Filter.Regex("HeroClass", new MongoDB.Bson.BsonRegularExpression(filter, "i"));
            return await _knightsCollection.Find(filterDefinition).ToListAsync();
        }

        public async Task<Knight> GetKnightByIdAsync(Guid id)
        {
            return await _knightsCollection.Find(k => k.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddKnightAsync(Knight knight)
        {
            knight.Id = Guid.NewGuid();
            await _knightsCollection.InsertOneAsync(knight);
        }

        public async Task UpdateKnightAsync(Knight knight)
        {
            await _knightsCollection.ReplaceOneAsync(k => k.Id == knight.Id, knight);
        }

        public async Task DeleteKnightAsync(Guid id)
        {
            await _knightsCollection.DeleteOneAsync(k => k.Id == id);
        }
    }
}