using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Repositories
{
    public class OfferCodeRepository : GenericRepository<OfferCode, Guid>, IOfferCodeRepository
    {
        private readonly HelioAppDbContext _context;

        public OfferCodeRepository(HelioAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OfferCode?> GetByCodeAsync(string code)
        {
            return await _context.OfferCodes
                .Include(c => c.Offer)
                .FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<IEnumerable<OfferCode>> GetByOfferIdAsync(Guid offerId)
        {
            return await _context.OfferCodes
                .Where(c => c.OfferId == offerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OfferCode>> GetAvailableCodesAsync(Guid offerId)
        {
            return await _context.OfferCodes
                .Where(c => c.OfferId == offerId && !c.IsUsed && (c.ExpiresAt == null || c.ExpiresAt > DateTime.UtcNow))
                .ToListAsync();
        }

        public async Task MarkAsUsedAsync(string code, Guid userId)
        {
            var offerCode = await _context.OfferCodes.FirstOrDefaultAsync(c => c.Code == code);
            if (offerCode == null)
                throw new KeyNotFoundException("Offer code not found.");

            offerCode.IsUsed = true;
            offerCode.UsedBy = userId.ToString();
            offerCode.UsedAt = DateTime.UtcNow;

            _context.OfferCodes.Update(offerCode);
            await _context.SaveChangesAsync();
        }
    }
}
