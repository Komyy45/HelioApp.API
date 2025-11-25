using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories;

internal sealed class NewsRepository(HelioAppDbContext context) : GenericRepository<News, Guid>(context), INewsRepository
{
    
}