using HelioApp.Application.Contracts.Repositories;
using HelioApp.Domain.Entities.Services___Categories;

namespace HelioApp.Application.Contracts
{
    public interface IServiceRepository : IGenericRepository<Service, Guid>
    {
    }
}
