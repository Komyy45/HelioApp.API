using HelioApp.Domain.Enums;

public sealed record AdDto(
    Guid Id,
    string Title,
    string? Content,
    string PictureUrl,
    string? VideoUrl,
    string CreatedBy,
    string? ExternalUrl,
    Guid? ReferralId,
    AdPlacement Placement,
    AdReferralType ReferralType,
    AdTargetAudience TargetAudience,
    int ImpressionCount,
    int ClickCount,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActive,
    int Priority,
    decimal? Budget,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
