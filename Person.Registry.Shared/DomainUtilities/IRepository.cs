using System.Linq.Expressions;
namespace Person.Registry.Shared.DomainUtilities
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task RemoveAsync(TEntity entity);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? expression);
    }
}
