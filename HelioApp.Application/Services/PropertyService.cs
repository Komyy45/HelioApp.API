using HelioApp.Application.Contracts.Blob;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Common;
using HelioApp.Application.DTOS.Properties;
using HelioApp.Domain.Entities.Properties;
using HelioApp.Domain.Specifications.Properties;

namespace HelioApp.Application.Services;

internal sealed class PropertyService(IPropertyRepository propertyRepository, IImageService imageService) : IPropertyService
{
    public async Task<PaginationResponse<PropertyDto>> GetAll(PaginationRequest request)
    {
        var spec = new GetAllPropertiesSpecification(null, request.PageSize, request.PageIndex);
        
        var properties = await propertyRepository.GetAllAsync(spec);
        
        var response = properties.Select(p => new PropertyDto(
            p.Id,
            p.Title,
            p.Images,
            p.Price,
            p.ExpiresAt,
            p.Location,
            p.ContactName,
            p.ContactPhone
            ));

        var propertiesCount = await propertyRepository.Count();
        var totalPages = (int)Math.Ceiling((float)propertiesCount / request.PageSize);

        return new PaginationResponse<PropertyDto>(
                response,
                PageSize: request.PageSize,
                CurrentPage: request.PageIndex,
                TotalItems:  propertiesCount,
                TotalPages: totalPages
            );
    }

    public async Task<PropertyDetailsDto> GetById(Guid id)
    {
       var property = await propertyRepository.GetByIdAsync(id);

       if (property is null) throw new Exception("Property Not Found!");
       
       var response = new PropertyDetailsDto(
           property.Id,
           property.Title,
           property.Description,
           property.Images,
           property.Price,
           property.ExpiresAt,
           property.Location,
           property.ContactName,
           property.ContactPhone,
           property.Amenities
           );

       return response;
    }

    public async Task<Guid> Create(CreatedPropertyDto createdProperty)
    {
        var property = new Property()
        {
            Title = createdProperty.Title,
            Description = createdProperty.Description,
            ExpiresAt = createdProperty.ExpirationDate,
            Price = createdProperty.Price,
            ContactName = createdProperty.ContactName,
            ContactPhone = createdProperty.ContactPhone,
            CreatedAt = DateTimeOffset.UtcNow,
            Amenities = createdProperty.Amenities,
            Location = createdProperty.Location,
            PropertyType = createdProperty.PropertyType,
            OwnerId = "00000000-0000-0000-0000-000000000001"
        };

        var images = new List<string>();

        foreach (var image in createdProperty.Images)
        {
            var imageUrl = await imageService.UploadImage(image);
            images.Add(imageUrl);
        }

        property.Images = images;
        
        await propertyRepository.AddAsync(property);

        await propertyRepository.CompleteAsync();
        
        return property.Id;
    }

    public async Task Update(UpdatedPropertyDto updatedProperty)
    {
        var property = await propertyRepository.GetByIdAsync(updatedProperty.Id);

        if (property is null) throw new Exception("Property Not Found!");

        foreach (var image in property.Images)
            await imageService.DeleteImage(image);

        var images = new List<string>();
        
        foreach (var image in updatedProperty.Images)
        {
            var imageUrl = await imageService.UploadImage(image);
            images.Add(imageUrl);
        }
        
        property.Title = updatedProperty.Title;
        property.Images = images;
        property.Description = updatedProperty.Description;
        property.Price = updatedProperty.Price;
        property.ContactName = updatedProperty.ContactName;
        property.ContactPhone = updatedProperty.ContactPhone;
        property.Location = updatedProperty.Location;
        property.Amenities = updatedProperty.Amenities;
        property.PropertyType = updatedProperty.PropertyType;
        property.ExpiresAt = updatedProperty.ExpirationDate;
        
        propertyRepository.Update(property);

        await propertyRepository.CompleteAsync();
    }

    public async Task Delete(Guid id)
    {
        var property = await propertyRepository.GetByIdAsync(id);

        if (property is null) throw new Exception("Property Not Found");
        
        foreach (var image in property.Images)
        {
            var isDeleted = await imageService.DeleteImage(image);
            if (!isDeleted) throw new Exception("Error Deleting Property Images.");
        }

        if (property is null) throw new Exception("Property Not Found!");
        
        propertyRepository.Delete(property);

        await propertyRepository.CompleteAsync();
    }
}