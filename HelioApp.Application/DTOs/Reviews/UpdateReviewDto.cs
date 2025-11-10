using HelioApp.Domain.Enums;

namespace HelioApp.Application.DTOs.Reviews;

public sealed record UpdateReviewDto(
    Guid Id,
    Guid ServiceId,
    Guid AuthorId,
    int Rating,
    string? Title,
    string Body,
    List<string>? Images,
    bool IsVerifiedPurchase,
    int HelpfulCount,
    ReviewStatus Status
    );