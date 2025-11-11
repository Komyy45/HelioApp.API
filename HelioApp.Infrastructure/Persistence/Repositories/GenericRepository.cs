using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Common;
using HelioApp.Domain.Contracts;
using HelioApp.Infrastructure.Helpers;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    //public virtual Task<TEntity?> GetByIdAsync(TKey id, Expression<Func<TEntity, bool>> criteria)
    //{
    //    var query = DbSet.Where(criteria);
    //    return query.FirstOrDefaultAsync(e => e.Id.Equals(id));
    //}

    public virtual Task<TEntity?> GetByIdAsync(TKey id, Expression<Func<TEntity, bool>> criteria)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "e");

        var idProperty = Expression.Property(parameter, "Id");
        var idValue = Expression.Constant(id);
        var idEquals = Expression.Equal(idProperty, idValue);

        var body = new ParameterReplacer(criteria.Parameters[0], parameter).Visit(criteria.Body);

        var combined = Expression.AndAlso(idEquals, body);

        var lambda = Expression.Lambda<Func<TEntity, bool>>(combined, parameter);

        return DbSet.FirstOrDefaultAsync(lambda);
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

    // Helper method to list entities based on specification
    public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity, TKey> spec)
    {
        IQueryable<TEntity> query = context.Set<TEntity>();

        if (spec.Criteria != null)
            query = query.Where(spec.Criteria);

        if (spec.Includes != null)
        {
            foreach (var include in spec.Includes)
                query = query.Include(include);
        }

        if (spec.OrderBy != null)
            query = query.OrderBy(spec.OrderBy);

        if (spec.IsPaginationEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);

        return await query.ToListAsync();
    }

}