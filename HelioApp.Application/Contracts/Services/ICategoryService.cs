using HelioApp.Application.DTOS;

namespace HelioApp.Application.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
