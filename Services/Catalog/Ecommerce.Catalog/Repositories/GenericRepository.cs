using Ecommerce.Catalog.Entities.Common;
using Ecommerce.Catalog.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Ecommerce.Catalog.Repositories
{
    public class GenericRepository<TEntity> 
        : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public GenericRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
        }
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            await _collection.FindOneAndDeleteAsync
                (x=> x.Id == id, cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _collection.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _collection.FindOneAndReplaceAsync
                (x => x.Id == entity.Id, entity, cancellationToken: cancellationToken);
        }
    }
}
