using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Contracts
{
    public interface ISubcategoryRepository : IGenericRepository<Subcategory, Guid>
    {
        Task<bool> HasServicesAsync(Guid subcategoryId);
    }
}
