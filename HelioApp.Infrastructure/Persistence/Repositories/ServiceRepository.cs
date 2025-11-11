using HelioApp.Application.Contracts;
using HelioApp.Domain.Contracts;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    internal sealed class ServiceRepository(HelioAppDbContext context) : GenericRepository<Service, Guid>(context), IServiceRepository
    {
        private readonly HelioAppDbContext _context = context;
        public async Task<IEnumerable<Service>> GetAllAsync(Guid subcategoryId, bool asNoTracking = true)
        {
            var query = DbSet.Where(s => s.SubcategoryId == subcategoryId);
            if (!asNoTracking) return await query.ToListAsync();
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetAllAsync(Guid subcategoryId, ISpecification<Service, Guid> spec, bool asNoTracking = true)
        {
            var query = DbSet.Where(s => s.SubcategoryId == subcategoryId).Evaluate(spec);
            if (!asNoTracking) return await query.ToListAsync();
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
