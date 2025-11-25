namespace HelioApp.Application.DTOs.ContentManagement;

public sealed record UpdateNewsDto(
    Guid AuthorId,
    string AuthorName,
    string Title,
    string Content,
    string? Summary,
    string FeaturedImageUrl,
    List<string>? Images,
    string? ExternalUrl,
    string? Category,
    bool IsFeatured,
    bool IsPublished,
    int ViewCount
    );