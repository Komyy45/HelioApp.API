namespace HelioApp.Application.DTOs.ContentManagement;

public sealed record CreateNewsDto(
    Guid AuthorId,
    string Title,
    string Content,
    string? Summary,
    // TODO : string FeaturedImageUrl,
    // TODO : List<string>? Images,
    string? ExternalUrl,
    string? Category,
    bool IsFeatured,
    bool IsPublished
    );