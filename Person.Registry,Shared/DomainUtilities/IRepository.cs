using System.Linq.Expressions;

namespace Person.Registry.Shared.DomainUtilities
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);

        Task<List<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids);

        Task AddAsync(TEntity aggregateRoot);

        Task UpdateAsync(TEntity aggregateRoot);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? expression);
    }
}
