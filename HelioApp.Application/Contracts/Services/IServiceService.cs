using HelioApp.Application.DTOS;

namespace HelioApp.Application.Contracts
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllAsync(Guid? subcategoryId = null);
        Task<ServiceDto?> GetByIdAsync(Guid id);
        Task<ServiceDto> CreateAsync(CreateServiceDto dto);
        Task<ServiceDto> UpdateAsync(UpdateServiceDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ToggleFavoriteAsync(Guid id);
    }
}
