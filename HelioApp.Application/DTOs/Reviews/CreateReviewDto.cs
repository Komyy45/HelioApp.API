namespace HelioApp.Application.DTOs.Reviews;

public sealed record CreateReviewDto(
    Guid ServiceId,
    Guid AuthorId,
    int Rating,
    string? Title,
    string Body
    // TODO: List<string>? Images
);