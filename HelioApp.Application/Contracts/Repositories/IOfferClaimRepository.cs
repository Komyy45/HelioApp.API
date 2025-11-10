using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Contracts.Repositories
{
    public interface IOfferClaimRepository : IGenericRepository<OfferClaim, Guid>
    {
        Task<OfferClaim?> GetByClaimCodeAsync(string claimCode);
        Task<IEnumerable<OfferClaim>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<OfferClaim>> GetByOfferIdAsync(Guid offerId);
        Task<int> CountByOfferIdAsync(Guid offerId);
        Task<bool> IsUserAlreadyClaimedAsync(Guid offerId, Guid userId);
    }
}
