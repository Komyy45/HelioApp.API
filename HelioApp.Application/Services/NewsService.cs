using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;

namespace HelioApp.Application.Services;

internal sealed class NewsService : INewsService
{
    public Task<IEnumerable<NewsDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(CreateNewsDto request)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateNewsDto request)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}