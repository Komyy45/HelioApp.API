using HelioApp.Application.DTOS;

namespace HelioApp.Application.Contracts
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllAsync(Guid subcategoryId);
        Task<ServiceDetailsDto> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(CreateServiceDto dto);
        Task<ServiceDetailsDto> UpdateAsync(UpdateServiceDto dto);
        Task DeleteAsync(Guid id);
    }
}
