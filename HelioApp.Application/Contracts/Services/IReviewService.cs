using HelioApp.Application.DTOs.Reviews;

namespace HelioApp.Application.Contracts.Services;

public interface IReviewService
{
    public Task<IEnumerable<ReviewDto>> GetAll();
    public Task<ReviewDto> GetById(Guid serviceId, Guid id);
    public Task<Guid> Create(CreateReviewDto createReviewDto);
    public Task Update(UpdateReviewDto updateReviewDto);
    public Task Delete(Guid serviceId, Guid id);
}