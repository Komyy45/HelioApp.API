using HelioApp.Application.Contracts;
using HelioApp.Application.DTOS;

namespace HelioApp.Application.Services
{
    internal sealed class ServiceService(IServiceRepository serviceRepository) : IServiceService
    {
        public Task<IEnumerable<ServiceDto>> GetAllAsync(Guid? subcategoryId = null)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDto> CreateAsync(CreateServiceDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDto> UpdateAsync(UpdateServiceDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ToggleFavoriteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
