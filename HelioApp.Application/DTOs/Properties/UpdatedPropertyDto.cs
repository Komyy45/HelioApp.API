using HelioApp.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace HelioApp.Application.DTOS.Properties;

public sealed record UpdatedPropertyDto(
    Guid Id,
    string Title,
    string Description,
    IFormFile[] Images,
    decimal Price,
    DateTime ExpirationDate,
    string Location,
    string ContactName,
    string ContactPhone,
    string Amenities,
    PropertyType PropertyType
    );