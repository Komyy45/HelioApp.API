using HelioApp.Application.Contracts;
using HelioApp.Application.Contracts.Blob;
using HelioApp.Application.DTOS;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Services
{
    internal sealed class ServiceService(IServiceRepository serviceRepository, IImageService imageService) : IServiceService
    {
        public async Task<IEnumerable<ServiceDto>> GetAllAsync(Guid subcategoryId)
        {
            var services = await serviceRepository.GetAllAsync(subcategoryId);

            var response = services.Select(s => new ServiceDto(
                    s.Id,
                    s.Title,
                    s.CoverImageUrl
                ));

            return response;
        }

        public async Task<ServiceDetailsDto> GetByIdAsync(Guid id)
        {
            var service = await serviceRepository.GetByIdAsync(id);

            if (service is null) throw new Exception("Service Not Found!");

            var response = new ServiceDetailsDto(
                    service.Id,
                    service.Title,
                    service.Description,
                    service.CoverImageUrl,
                    service.Address,
                    service.SubcategoryId,
                    service.CreatedAt,
                    "",
                    service.Phone,
                    service.Whatsapp,
                    service.Email
                    );

            return response;
        }

        public async Task<Guid> CreateAsync(CreateServiceDto request)
        {
            
            var coverImageUrl = request.CoverImage is null ? null : await imageService.UploadImage(request.CoverImage);
            
            var service = new Service()
            {
                SubcategoryId = request.SubcategoryId,
                CoverImageUrl = coverImageUrl,
                Title = request.Title,  
                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Whatsapp = request.Whatsapp,
                Email = request.Email,
                WebsiteUrl = request.WebsiteUrl,
                LocationLat = request.LocationLat,
                LocationLng = request.LocationLng,
                ProviderId = "00000000-0000-0000-0000-000000000001"
            };

            await serviceRepository.AddAsync(service);

            await serviceRepository.CompleteAsync();

            return service.Id;
        }

        public Task<ServiceDetailsDto> UpdateAsync(UpdateServiceDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var service = await serviceRepository.GetByIdAsync(id);

            if (service is null) throw new Exception("Service Not Found!");

            serviceRepository.Delete(service);

            await serviceRepository.CompleteAsync();
        }
    }
}
