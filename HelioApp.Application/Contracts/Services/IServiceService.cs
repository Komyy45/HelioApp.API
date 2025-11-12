using HelioApp.Application.DTOS;
using HelioApp.Application.DTOs.Common;

namespace HelioApp.Application.Contracts
{
    public interface IServiceService
    {
        Task<PaginationResponse<ServiceDto>> GetAllAsync(Guid subcategoryId, PaginationRequest request);
        Task<ServiceDetailsDto> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(CreateServiceDto dto);
        Task<ServiceDetailsDto> UpdateAsync(UpdateServiceDto dto);
        Task DeleteAsync(Guid id);
    }
}
