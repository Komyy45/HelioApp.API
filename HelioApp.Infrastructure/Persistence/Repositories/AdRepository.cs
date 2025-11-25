using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories;

public sealed class AdRepository(HelioAppDbContext context) : GenericRepository<Ad, Guid>(context),IAdRepository
{
    
}