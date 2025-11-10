using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category, Guid>
    {
        Task<bool> HasSubcategoriesAsync(Guid categoryId);
    }
}
