using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories;

internal sealed class AdRepository(HelioAppDbContext context) : GenericRepository<Ad, Guid>(context)
{
    
}