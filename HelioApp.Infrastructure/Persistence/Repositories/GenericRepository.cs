using System.Linq.Expressions;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Common;
using HelioApp.Domain.Contracts;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories;

public abstract class GenericRepository<TEntity,TKey>(HelioAppDbContext context) : IGenericRepository<TEntity,TKey>
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
{
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = true)
    {
        if (asNoTracking) return await DbSet.AsNoTracking().ToListAsync();
        return await DbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> spec, bool asNoTracking = true)
    {
        var query = DbSet.Evaluate(spec);
        if(asNoTracking)
            return await query.AsNoTracking().ToListAsync();
        return await query.ToListAsync();
    }

    public virtual Task<TEntity?> GetByIdAsync(TKey id)
    {
        return DbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public virtual Task<TEntity?> GetByIdAsync(TKey id, Expression<Func<TEntity, bool>> criteria)
    {
        var query = DbSet.Where(criteria);
        return query.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public virtual async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }
}