using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.ContentManagement;
using HelioApp.Domain.Entities.ContentManagement;

namespace HelioApp.Application.Services;

internal sealed class NewsService : INewsService
{
    private readonly INewsRepository newsRepository;
    private readonly IMapper mapper;

    public NewsService(INewsRepository newsRepository, IMapper mapper)
    {
        this.newsRepository = newsRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<NewsDto>> GetAll()
    {
        var newsList = await newsRepository.GetAllAsync();
        return mapper.Map<IEnumerable<NewsDto>>(newsList);
    }

    public async Task<Guid> Create(CreateNewsDto request)
    {
        var entity = mapper.Map<News>(request);
        await newsRepository.AddAsync(entity);
        await newsRepository.CompleteAsync();
        return entity.Id;
    }

    public async Task Update(Guid id, UpdateNewsDto request)
    {
        var existing = await newsRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("News not found");

        mapper.Map(request, existing);

        newsRepository.Update(existing);
        await newsRepository.CompleteAsync();
    }

    public async Task Delete(Guid id)
    {
        var existing = await newsRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException("News not found");

        newsRepository.Delete(existing);
        await newsRepository.CompleteAsync();
    }
}