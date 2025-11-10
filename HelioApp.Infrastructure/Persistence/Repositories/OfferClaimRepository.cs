using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    public class OfferClaimRepository : GenericRepository<OfferClaim, Guid>, IOfferClaimRepository
    {
        private readonly HelioAppDbContext _context;

        public OfferClaimRepository(HelioAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OfferClaim?> GetByClaimCodeAsync(string claimCode) => await _context.OfferClaims
                .Include(c => c.Offer)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.ClaimCode == claimCode);

        public async Task<IEnumerable<OfferClaim>> GetByUserIdAsync(Guid userId)
        {
            return await _context.OfferClaims
                .Include(c => c.Offer)
                .Where(c => c.UserId == userId.ToString())
                .ToListAsync();
        }

        public async Task<IEnumerable<OfferClaim>> GetByOfferIdAsync(Guid offerId)
        {
            return await _context.OfferClaims
                .Include(c => c.User)
                .Where(c => c.OfferId == offerId)
                .ToListAsync();
        }

        public async Task<int> CountByOfferIdAsync(Guid offerId)
        {
            return await _context.OfferClaims
                .CountAsync(c => c.OfferId == offerId);
        }

        public async Task<bool> IsUserAlreadyClaimedAsync(Guid offerId, Guid userId)
        {
            return await _context.OfferClaims
                .AnyAsync(c => c.OfferId == offerId && c.UserId == userId.ToString());
        }
    }
}
