using HelioApp.Domain.Common;
using HelioApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> Evaluate<TEntity, TKey>(this IQueryable<TEntity> query, ISpecification<TEntity, TKey> spec)
    where TEntity : BaseEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        if (spec.Criteria is not null)
            query = query.Where(spec.Criteria);

        if (spec.Includes is not null)
            query = spec.Includes.Aggregate(query, (q, i) => q.Include(i));

        if (spec.IsPaginationEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);
        
        return query;
    }
}