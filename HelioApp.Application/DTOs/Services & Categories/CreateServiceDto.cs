namespace HelioApp.Application.DTOS;

public record CreateServiceDto(string Title, string? Description, decimal Price, Guid? SubcategoryId);