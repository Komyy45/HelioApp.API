using HelioApp.Application.DTOs.Offers;

namespace HelioApp.Application.Contracts.Services
{
    public interface IOfferClaimService
    {
        Task<IEnumerable<OfferClaimDto>> GetAllAsync();
        Task<OfferClaimDto?> GetByIdAsync(Guid id);
        Task<OfferClaimDto> CreateAsync(CreateOfferClaimDto dto);
        Task UpdateAsync(UpdateOfferClaimDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
