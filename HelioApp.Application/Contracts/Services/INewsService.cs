using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Contracts.Services;

public interface INewsService
{
    public Task<IEnumerable<NewsDto>> GetAll();

    public Task<Guid> Create(CreateNewsDto request);

    public Task Update(UpdateNewsDto request);

    public Task Delete(Guid id);
}