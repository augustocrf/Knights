using Knights.Core.Entities;
using Knights.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Knights.Infrastructure.Repositories
{
    public class PowerRepository : IPowerRepository
    {
        private readonly IMongoCollection<Power> _powersCollection;

        public PowerRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MonPowersnnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _powersCollection = database.GetCollection<Power>("Powers");
        }

        public async Task<IEnumerable<Power>> GetPowersAsync()
        {
            return await _powersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Power>> GetPowersByFilterAsync(string filter)
        {
            var filterDefinition = Builders<Power>.Filter.Regex("Description", new MongoDB.Bson.BsonRegularExpression(filter, "i"));
            return await _powersCollection.Find(filterDefinition).ToListAsync();
        }

        public async Task<Power> GetPowerByIdAsync(Guid id)
        {
            return await _powersCollection.Find(k => k.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddPowerAsync(Power power)
        {
            power.Id = Guid.NewGuid();
            await _powersCollection.InsertOneAsync(power);
        }

        public async Task UpdatePowerAsync(Power power)
        {
            await _powersCollection.ReplaceOneAsync(k => k.Id == power.Id, power);
        }

        public async Task DeletePowerAsync(Guid id)
        {
            await _powersCollection.DeleteOneAsync(k => k.Id == id);
        }
    }
}