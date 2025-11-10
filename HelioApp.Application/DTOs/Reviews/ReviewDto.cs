using HelioApp.Domain.Enums;

namespace HelioApp.Application.DTOs.Reviews;

public sealed record ReviewDto(
        Guid Id,
        Guid ServiceId,
        Guid AuthorId,
        int Rating,
        string? Title,
        string Body,
        List<string>? Images,
        bool IsVerifiedPurchase,
        int HelpfulCount,
        ReviewStatus Status,
        DateTimeOffset CreatedAt,
        DateTimeOffset? UpdatedAt
        // DateTimeOffset? DeletedAt
        // ApplicationUser Author,
        // Service Service,
        // ReviewReply? Reply
    );