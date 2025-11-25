using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Contracts.Services;

public interface INewsService
{
    Task<IEnumerable<NewsDto>> GetAll();

    Task<Guid> Create(CreateNewsDto request);

    Task Update(Guid id, UpdateNewsDto request);

    Task Delete(Guid id);
}
