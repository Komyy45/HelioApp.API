using HelioApp.Application.DTOs.Community;

namespace HelioApp.Application.Contracts.Services;

public interface IDiscussionCircleService
{
    public Task<IEnumerable<DiscussionCircleDto>> GetAll();

    public Task<Guid> Create(CreateDiscussionCircleDto request);

    public Task Update(Guid id, UpdateDiscussionCircleDto request);

    public Task Delete(Guid id);
}