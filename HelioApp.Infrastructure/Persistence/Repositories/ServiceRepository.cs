using HelioApp.Application.Contracts;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Infrastructure.Persistence.Data;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository(HelioAppDbContext context) : GenericRepository<Service, Guid>(context), IServiceRepository
    {
        private readonly HelioAppDbContext _context = context;
    }
}
