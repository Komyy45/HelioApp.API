using HelioApp.Application.Contracts;
using HelioApp.Application.Contracts.Blob;
using HelioApp.Application.DTOS;
using HelioApp.Application.DTOs.Common;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Domain.Specifications.Services___Categories;

namespace HelioApp.Application.Services
{
    internal sealed class ServiceService(IServiceRepository serviceRepository, IImageService imageService) : IServiceService
    {
        public async Task<PaginationResponse<ServiceDto>> GetAllAsync(Guid subcategoryId, PaginationRequest request)
        {
            var spec = new GetAllServicesSpecification(
                    criteria: s => s.SubcategoryId == subcategoryId,
                    pageSize: request.PageSize,
                    pageIndex: request.PageIndex
                );
            
            var services = await serviceRepository.GetAllAsync(spec);

            var response = services.Select(s => new ServiceDto(
                    s.Id,
                    s.Title,
                    s.CoverImageUrl
                ));

            var serviceCount = await serviceRepository.Count(s => s.SubcategoryId == subcategoryId);

            var totalPages = (int)Math.Ceiling((float)serviceCount / request.PageSize);
            
            return new PaginationResponse<ServiceDto>(
                 response,
                 TotalItems: serviceCount,
                 PageSize: request.PageSize,
                 TotalPages: totalPages,
                 CurrentPage: request.PageIndex
                );
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
                $"https://www.google.com/maps?q={service.LocationLat},{service.LocationLng}",
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
