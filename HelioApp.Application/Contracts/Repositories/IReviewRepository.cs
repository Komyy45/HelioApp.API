using HelioApp.Domain.Entities.Reviews;
using HelioApp.Domain.Specifications;
using System.Linq.Expressions;

namespace HelioApp.Application.Contracts.Repositories;

public interface IReviewRepository : IGenericRepository<Review, Guid>
{
    Task<Review?> GetByIdAsync(Guid id, Expression<Func<Review, bool>>? predicate = null);

    Task<IEnumerable<Review>> GetByServiceIdAsync(Guid serviceId, bool asNoTracking = true);
    Task<double> GetAverageRatingByServiceIdAsync(Guid serviceId);
    Task<IReadOnlyList<Review>> ListReviewsBySpecificationAsync(ReviewSpecification spec);
}