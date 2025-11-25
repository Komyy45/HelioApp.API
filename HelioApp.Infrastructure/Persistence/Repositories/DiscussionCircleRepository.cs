using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Community;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
        public sealed class DiscussionCircleRepository(HelioAppDbContext context)
            : GenericRepository<DiscussionCircle, Guid>(context), IDiscussionCircleRepository
        {
            
        }
}
