using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Contracts;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Contracts
{
    public interface IServiceRepository : IGenericRepository<Service, Guid>
    {
        Task<IEnumerable<Service>> GetAllAsync(Guid subcategoryId, bool asNoTracking = true);
        Task<IEnumerable<Service>> GetAllAsync(Guid subcategoryId, ISpecification<Service, Guid> spec, bool asNoTracking = true);
    }
}
