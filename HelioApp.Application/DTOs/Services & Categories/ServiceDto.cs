namespace HelioApp.Application.DTOS;

public record ServiceDto(Guid Id, string Title, string? Description, decimal Price, Guid? SubcategoryId, bool IsFavorite, DateTime CreatedAt);