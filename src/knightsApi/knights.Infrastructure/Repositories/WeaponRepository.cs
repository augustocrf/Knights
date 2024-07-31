using Knights.Core.Entities;
using Knights.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Knights.Infrastructure.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly IMongoCollection<Weapon> _weaponCollection;

        public WeaponRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _weaponCollection = database.GetCollection<Weapon>("Weapon");
        }

        public async Task<IEnumerable<Weapon>> GetWeaponsAsync()
        {
            return await _weaponCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<Weapon>> GetWeaponsByFilterAsync(string filter)
        {
            var filterDefinition = Builders<Weapon>.Filter.Regex("Name", new MongoDB.Bson.BsonRegularExpression(filter, "i"));
            return await _weaponCollection.Find(filterDefinition).ToListAsync();
        }

        public async Task<Weapon> GetWeaponByIdAsync(Guid id)
        {
            return await _weaponCollection.Find(k => k.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddWeaponAsync(Weapon weapon)
        {
            weapon.Id = Guid.NewGuid();
            await _weaponCollection.InsertOneAsync(weapon);
        }

        public async Task UpdateWeaponAsync(Weapon weapon)
        {
            await _weaponCollection.ReplaceOneAsync(k => k.Id == weapon.Id, weapon);
        }

        public async Task DeleteWeaponAsync(Guid id)
        {
            await _weaponCollection.DeleteOneAsync(k => k.Id == id);
        }
    }
}