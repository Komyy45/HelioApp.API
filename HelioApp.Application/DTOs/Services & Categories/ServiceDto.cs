namespace HelioApp.Application.DTOS;

public sealed record ServiceDto(
    Guid Id,
    string Title,
    string? CoverImageUrl
    );