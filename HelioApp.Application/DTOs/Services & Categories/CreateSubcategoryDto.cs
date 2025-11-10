namespace HelioApp.Application.DTOS;

public record CreateSubcategoryDto(
    Guid CategoryId,
    string Name
    );