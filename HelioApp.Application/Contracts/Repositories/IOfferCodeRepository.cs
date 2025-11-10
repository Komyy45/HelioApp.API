
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Contracts.Repositories
{
    public interface IOfferCodeRepository : IGenericRepository<OfferCode, Guid>
    {
        Task<OfferCode?> GetByCodeAsync(string code);
        Task<IEnumerable<OfferCode>> GetByOfferIdAsync(Guid offerId);
        Task<IEnumerable<OfferCode>> GetAvailableCodesAsync(Guid offerId);
        Task MarkAsUsedAsync(string code, Guid userId);
    }
}
