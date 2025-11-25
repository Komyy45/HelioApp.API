namespace HelioApp.Application.DTOs.Community;

public sealed record DiscussionCircleDto(
    Guid Id,
    string Name,
    string? NameAr,
    string? Description,
    string? IconUrl,
    string? CoverImageUrl,
    string? Rules,
    bool IsActive,
    int PostsCount,
    int MembersCount,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt
);