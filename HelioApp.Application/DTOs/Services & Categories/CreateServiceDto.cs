using Microsoft.AspNetCore.Http;

namespace HelioApp.Application.DTOS;

public record CreateServiceDto(
    Guid SubcategoryId,
    IFormFile? CoverImage, 
    string Title,
    string Description,
    string Address,
    decimal? LocationLat,
    decimal? LocationLng,
    string Location,
    string Phone,
    string? Whatsapp, 
    string? Email,
    string? WebsiteUrl
    );