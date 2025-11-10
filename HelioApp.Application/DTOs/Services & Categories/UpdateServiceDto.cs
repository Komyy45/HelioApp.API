namespace HelioApp.Application.DTOS;

public record UpdateServiceDto(Guid Id, string Title, string? Description, decimal Price, Guid? SubcategoryId);