using HelioApp.Application.DTOs.Offers;

namespace HelioApp.Application.Contracts.Services
{
    public interface IOfferCodeService
    {
        Task<IEnumerable<OfferCodeDto>> GetAllAsync();
        Task<OfferCodeDto?> GetByIdAsync(Guid id);
        Task<OfferCodeDto> CreateAsync(CreateOfferCodeDto dto);
        Task UpdateAsync(UpdateOfferCodeDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
