using HelioApp.Application.Contracts;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    public class SubcategoryRepository(HelioAppDbContext context) : GenericRepository<Subcategory, Guid>(context), ISubcategoryRepository
    {
        private readonly HelioAppDbContext _context = context;
        
        public async Task<bool> HasServicesAsync(Guid subcategoryId)
        {
            return await _context.Services.AnyAsync(s => s.SubcategoryId == subcategoryId);
        }
    }
}
