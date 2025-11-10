using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Contracts.Repositories;

public interface INewsRepository : IGenericRepository<News, Guid>
{
    
}