namespace HelioApp.Application.DTOS;

public record UpdateCategoryDto(Guid Id, 
    string Name,
    string NameAr,
    string Description,
    int DisplayOrder,
    string IconUrl
    );