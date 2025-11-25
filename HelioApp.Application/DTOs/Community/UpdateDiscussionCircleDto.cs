namespace HelioApp.Application.DTOs.Community;

public sealed record UpdateDiscussionCircleDto(
    string Name,
    string? NameAr,
    string? Description,
    string? IconUrl,
    string? CoverImageUrl,
    string? Rules,
    bool IsActive,
    int PostsCount,
    int MembersCount
);