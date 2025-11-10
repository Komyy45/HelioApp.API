using HelioApp.Application.Contracts.Blob;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOS.Properties;
using HelioApp.Domain.Entities.Properties;

namespace HelioApp.Application.Services;

internal sealed class PropertyService(IPropertyRepository propertyRepository, IImageService imageService) : IPropertyService
{
    public async Task<IEnumerable<PropertyDto>> GetAll()
    {
        var properties = await propertyRepository.GetAllAsync();
        
        var response = properties.Select(p => new PropertyDto());

        return response;
    }

    public async Task<PropertyDetailsDto> GetById(Guid id)
    {
       var property = await propertyRepository.GetByIdAsync(id);

       var response = new PropertyDetailsDto();

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
        var property = await propertyRepository.GetByIdAsync(new Guid());

        if (property is null) throw new Exception("Property Not Found!");
        
        propertyRepository.Update(property);

        await propertyRepository.CompleteAsync();
    }

    public async Task Delete(Guid id)
    {
        var property = await propertyRepository.GetByIdAsync(new Guid());

        if (property is null) throw new Exception("Property Not Found!");
        
        propertyRepository.Delete(property);

        await propertyRepository.CompleteAsync();
    }
}