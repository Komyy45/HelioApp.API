namespace HelioApp.Application.DTOS
{
    public record CategoryDto(Guid Id, string Name, IEnumerable<SubcategoryDto> Subcategories);
}
