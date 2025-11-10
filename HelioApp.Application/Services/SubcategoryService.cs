using HelioApp.Application.Contracts;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOS;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Services
{
    internal sealed class SubcategoryService(ISubcategoryRepository subRepo) : ISubcategoryService
    {

        public async Task<IEnumerable<SubcategoryDto>> GetAllAsync(Guid categoryId)
        {
            var subcategories = await subRepo.GetAllAsync();

            var response = subcategories.Select(s => new SubcategoryDto(
                s.Id,
                s.Name,
                s.CategoryId
            ));

            return response;
        }

        public async Task<SubcategoryDto?> GetByIdAsync(Guid categoryId, Guid id)
        {
            var subcategory = await subRepo.GetByIdAsync(id);

            if (subcategory is null) throw new Exception("Subcategory not found!");
            
            var response = new SubcategoryDto(
                    subcategory.Id,
                    subcategory.Name,
                    subcategory.CategoryId
                );

            return response;
        }

        public async Task<SubcategoryDto> CreateAsync(CreateSubcategoryDto dto)
        {
            var subcategory = new Subcategory()
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name
            };

            await subRepo.AddAsync(subcategory);

            await subRepo.CompleteAsync();

            return new SubcategoryDto(subcategory.Id, dto.Name, dto.CategoryId);
        }

        public async Task<SubcategoryDto> UpdateAsync(UpdateSubcategoryDto dto)
        {
            var subcategory = await subRepo.GetByIdAsync(dto.Id);

            if (subcategory is null) throw new Exception("Subcategory Not Found!");
            
            subRepo.Update(subcategory);

            await subRepo.CompleteAsync();

            return new SubcategoryDto(subcategory.Id, subcategory.Name, subcategory.CategoryId);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var subcategory = await subRepo.GetByIdAsync(id);

            if (subcategory is null) throw new Exception("Subcategory Not Found!");
            
            subRepo.Delete(subcategory);

            await subRepo.CompleteAsync();

            return true;
        }
    }
}
