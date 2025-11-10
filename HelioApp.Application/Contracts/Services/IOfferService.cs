using HelioApp.Application.DTOs.Offers;

namespace HelioApp.Application.Contracts.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferDto>> GetAllAsync();
        Task<OfferDto?> GetByIdAsync(Guid id);
        Task<OfferDto> CreateAsync(CreateOfferDto dto);
        Task UpdateAsync(UpdateOfferDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
