namespace HelioApp.Application.DTOS;

public record ServiceDetailsDto(Guid Id,
    string Title,
    string Description,
    string? CoverImageUrl, 
    string Address,
    Guid SubcategoryId, 
    DateTimeOffset CreatedAt,
    string Location,
    string Phone,
    string? Whatsapp, 
    string? Email);