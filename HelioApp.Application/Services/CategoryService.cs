using HelioApp.Application.Contracts;
using HelioApp.Application.DTOS;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Services
{
    internal sealed class CategoryService(ICategoryRepository categoryRepository)
        : ICategoryService
    {
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            // 1. Fetch All the categories from the Database
            var categories = await categoryRepository.GetAllAsync();

            // 2. Map them to the Response Model Format
            var response = categories.Select(c => new CategoryDto(
                    c.Id,
                    c.Name,
                    c.Subcategories.Select(sub => new SubcategoryDto(sub.Id, 
                        sub.Name, 
                        sub.CategoryId))
                    ));

            return response;
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            // 1. Fetch the category from the Database
            var category = await categoryRepository.GetByIdAsync(id);

            // 2. throw NotFoundException if not found
            if (category is null) throw new Exception("Category Not Found!");
            
            // // 3. Cast it to Response Model Format
            var subCategories = category.Subcategories.Select(sub => new SubcategoryDto(
                sub.Id,
                sub.Name,
                sub.CategoryId));
            
            return new CategoryDto(category.Id, category.Name, subCategories);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto c)
        {
            // 1. Create the new Category.
            var category = new Category()
            {
                Name = c.Name,
                NameAr = c.NameAr,
                Description = c.Description,
                DisplayOrder = c.DisplayOrder,
                IconUrl = c.IconUrl,
                UpdatedAt = DateTime.UtcNow
            };

            // 2. Persist the Changes to the database.
            await categoryRepository.AddAsync(category);

            await categoryRepository.CompleteAsync();

            return new CategoryDto(category.Id, category.Name, []);
        }

        public async Task UpdateAsync(UpdateCategoryDto c)
        {
            // 1. Fetch Category from the Database.
            var category = await categoryRepository.GetByIdAsync(c.Id);
            
            // 2. if it doesn't exists throw a Not Found Exception.
            if (category is null) throw new Exception("Category Not Found!");
            
            // 3. Update with new data.
            category.Name = c.Name;
            category.NameAr = c.NameAr;
            category.Description = c.Description;
            category.DisplayOrder = c.DisplayOrder;
            category.IconUrl = c.IconUrl;
            category.UpdatedAt = DateTime.UtcNow;
            
            // 4. Persist Changes to the Database.
            categoryRepository.Update(category);
            
            await categoryRepository.CompleteAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            // 1. Fetch the Category from the database
            var category = await categoryRepository.GetByIdAsync(id);
            
            // 1.1  If the category doesn't exists just return false
            if (category is null) return false;
            
            // 2. Delete the Category 
            categoryRepository.Delete(category);
            
            await categoryRepository.CompleteAsync();

            return true;
        }
    }
}