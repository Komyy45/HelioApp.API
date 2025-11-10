using HelioApp.Domain.Entities.Reviews;

namespace HelioApp.Application.Contracts.Repositories;

public interface IReviewRepository : IGenericRepository<Review, Guid>
{
    
}