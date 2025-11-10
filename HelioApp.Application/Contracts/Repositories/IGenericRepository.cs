using System.Linq.Expressions;
using HelioApp.Domain.Common;
using HelioApp.Domain.Contracts;

namespace HelioApp.Application.Contracts.Repositories;

public interface IGenericRepository<TEntity, TKey>
 where TEntity : BaseEntity<TKey>
 where TKey : IEquatable<TKey>
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> spec, bool asNoTracking = true);
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TEntity?> GetByIdAsync(TKey id, Expression<Func<TEntity, bool>> criteria);

    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> CompleteAsync();
}