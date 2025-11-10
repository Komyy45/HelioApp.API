using HelioApp.Application.Contracts;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    internal class CategoryRepository(HelioAppDbContext context) : GenericRepository<Category, Guid>(context), ICategoryRepository
    {
        private readonly HelioAppDbContext _context = context;

        public override async Task<IEnumerable<Category>> GetAllAsync(bool asNoTracking = true)
        {
            if (asNoTracking) return await DbSet.Include(c => c.Subcategories).AsNoTracking().ToListAsync();
            return await DbSet.ToListAsync();
        }

        public async Task<bool> HasSubcategoriesAsync(Guid categoryId)
        {
            return await _context.Subcategories.AnyAsync(s => s.CategoryId == categoryId);
        }
    }
}

