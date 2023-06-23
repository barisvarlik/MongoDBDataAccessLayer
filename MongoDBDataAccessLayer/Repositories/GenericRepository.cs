using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using ExampleCoreLayer.Repositories;

namespace MongoDBDataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepository(IOptions<DatabaseSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = database.GetCollection<T>(dbSettings.Value.CollectionName);
        }

        public async Task CreateManyAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public async Task CreateOneAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteOneAsync(string id)
        {
            await _collection.DeleteOneAsync(id);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetOneAsync(string id)
        {
            FilterDefinition<T> filterDefinition = Builders<T>.Filter.Eq("Id", id);
            return await _collection.Find(filterDefinition).FirstOrDefaultAsync();
        }

        public async Task UpdateOneAsync(string id, T entity)
        {
            FilterDefinition<T> filterDefinition = Builders<T>.Filter.Eq("Id", id);
            // UpdateDefinition<T> updateDefinition = Builders<T>.Update.DesiredUpdateMethod
            return;
        }
    }
}
