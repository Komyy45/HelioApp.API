using System.Linq.Expressions;
using HelioApp.Domain.Common;
using HelioApp.Domain.Contracts;

namespace HelioApp.Domain.Specifications;

public abstract class BaseSpecifications<TEntity, TKey>  : ISpecification<TEntity, TKey> 
    where TEntity : BaseEntity<TKey> 
    where TKey : IEquatable<TKey>
{
    public Expression<Func<TEntity, bool>>? Criteria { get; set; } = default!;    
    public List<Expression<Func<TEntity, object>>>? Includes { get; set; } = default!;    
    public Expression<Func<TEntity, object>>? OrderBy { get; set; } = default!;
    public bool IsPaginationEnabled { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }

    protected BaseSpecifications(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected virtual void AddIncludes()
    {
        Includes = new();
    }

    protected virtual void AddOrderBy()
    {
        
    }
    
    protected void AddPagination(int take, int skip)
    {
        IsPaginationEnabled = true;
        Take = take;
        Skip = skip;
    }
}