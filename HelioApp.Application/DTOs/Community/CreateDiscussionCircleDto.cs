namespace HelioApp.Application.DTOs.Community;

public sealed record CreateDiscussionCircleDto(
    string Name,
    string? NameAr,
    string? Description,
    string? IconUrl,
    string? CoverImageUrl,
    string? Rules,
    bool IsActive
);
