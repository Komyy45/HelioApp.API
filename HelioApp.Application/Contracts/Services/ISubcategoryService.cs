using HelioApp.Application.DTOS;

namespace HelioApp.Application.Contracts.Services;

public interface ISubcategoryService
{
    Task<IEnumerable<SubcategoryDto>> GetAllAsync(Guid categoryId);
    Task<SubcategoryDto?> GetByIdAsync(Guid categoryId, Guid id);
    Task<SubcategoryDto> CreateAsync(CreateSubcategoryDto dto);
    Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto dto);
    Task<bool> DeleteAsync(Guid id);
}