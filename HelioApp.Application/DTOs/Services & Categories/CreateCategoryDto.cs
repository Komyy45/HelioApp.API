namespace HelioApp.Application.DTOS;

public record CreateCategoryDto( 
    string Name,
    string NameAr,
    string Description,
    int DisplayOrder,
    string IconUrl);