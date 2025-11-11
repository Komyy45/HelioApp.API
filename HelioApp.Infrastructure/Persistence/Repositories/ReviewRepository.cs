using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Reviews;
using HelioApp.Domain.Specifications;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelioApp.Infrastructure.Persistence.Repositories
{

    internal sealed class ReviewRepository : GenericRepository<Review, Guid>, IReviewRepository
    {
        private readonly HelioAppDbContext _context;
        private readonly DbSet<Review> _reviews;

        public ReviewRepository(HelioAppDbContext context) : base(context)
        {
            _context = context;
            _reviews = _context.Set<Review>();
        }

        // Get by id with an optional predicate for extra filtering (e.g. by serviceId)
        public async Task<Review?> GetByIdAsync(Guid id, Expression<Func<Review, bool>>? predicate = null)
        {
            IQueryable<Review> query = _reviews.AsNoTracking().Where(r => r.Id == id);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Review>> GetByServiceIdAsync(Guid serviceId, bool asNoTracking = true)
        {
            var query = _reviews.Where(r => r.ServiceId == serviceId);

            if (asNoTracking)
                return await query.AsNoTracking().ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<double> GetAverageRatingByServiceIdAsync(Guid serviceId)
        {
            return await _reviews
                .Where(r => r.ServiceId == serviceId)
                .AverageAsync(r => (double?)r.Rating) ?? 0.0;
        }

        public async Task<IReadOnlyList<Review>> ListReviewsBySpecificationAsync(ReviewSpecification spec)
        {
            return await ListAsync(spec);
        }
    }
}