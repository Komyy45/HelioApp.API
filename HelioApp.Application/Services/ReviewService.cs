using AutoMapper;
using HelioApp.Application.Contracts.Repositories;
using HelioApp.Application.Contracts.Services;
using HelioApp.Application.DTOs.Reviews;
using HelioApp.Domain.Entities.Reviews;

namespace HelioApp.Application.Services;

internal sealed class ReviewService(IReviewRepository reviewRepository, IMapper mapper) : IReviewService
{
    public async Task<IEnumerable<ReviewDto>> GetAll()
    {
        var reviews = await reviewRepository.GetAllAsync();
        var response = mapper.Map<IEnumerable<ReviewDto>>(reviews);
        return response;
    }

    public async Task<ReviewDto> GetById(Guid serviceId, Guid id)
    {
        var review = await reviewRepository.GetByIdAsync(id, r => r.ServiceId.Equals(serviceId));
        if (review is null) throw new Exception("Review Not Found");
        var response = mapper.Map<ReviewDto>(review);
        return response;
    }

    public async Task<Guid> Create(CreateReviewDto createReviewDto)
    {
        var review = mapper.Map<Review>(createReviewDto);
        await reviewRepository.AddAsync(review);
        await reviewRepository.CompleteAsync();
        return review.Id;
    }

    public async Task Update(UpdateReviewDto updateReviewDto)
    {
        var review = await reviewRepository.GetByIdAsync(updateReviewDto.Id, r => r.ServiceId.Equals(updateReviewDto.ServiceId));
        if (review is null) throw new Exception("Review Not Found");
        

        review.Body = updateReviewDto.Body;
        review.Rating = updateReviewDto.Rating;
        review.Status = updateReviewDto.Status;
        review.Title = updateReviewDto.Title;
        review.IsVerifiedPurchase = updateReviewDto.IsVerifiedPurchase;
        review.HelpfulCount = updateReviewDto.HelpfulCount;
        
        reviewRepository.Update(review);

        await reviewRepository.CompleteAsync();
    }

    public async Task Delete(Guid serviceId, Guid id)
    {
        var review = await reviewRepository.GetByIdAsync(id, r => r.ServiceId.Equals(serviceId));
        if (review is null) throw new Exception("Review Not Found");
        reviewRepository.Delete(review);
        await reviewRepository.CompleteAsync();
    }
}