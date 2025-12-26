using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Order.Persistence.Concrete
{
    public class GenericRepository<TEntity>(AppDbContext context)
        : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> table = context.Set<TEntity>();
        public async Task CreateAsync(TEntity entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await table.FindAsync(id);
            if (entity != null)
            {
                table.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await table.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var record = await table.FindAsync(id);
            if (record == null)
            {
                throw new KeyNotFoundException($"{typeof(TEntity).Name} with id {id} not found.");
            }
            return record;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
