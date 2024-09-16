using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Person.Registry.Shared.DomainUtilities;

namespace Person.Registry.Core.Infrastructure.Database
{
    public class BaseRepository<TContext, TEntity> : IRepository<TEntity>
          where TEntity : class
          where TContext : DbContext
    {
        TContext _context;

        public BaseRepository(TContext context) =>
            _context = context;

        public async Task<TEntity> GetByIdAsync(int id) =>
            await _context.Set<TEntity>()
                          .FindAsync(id);

        public async Task AddAsync(TEntity aggregateRoot)
        {
            await _context.Set<TEntity>()
                          .AddAsync(aggregateRoot);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity aggregateRoot)
        {
            _context.Entry(aggregateRoot).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? expression)
            => expression == null ? _context.Set<TEntity>()
                                            .AsQueryable() :
                                    _context.Set<TEntity>()
                                            .Where(expression);

        public async Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>()
                 .Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
