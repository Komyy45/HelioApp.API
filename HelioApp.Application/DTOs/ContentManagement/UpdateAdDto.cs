using HelioApp.Domain.Enums;

public sealed record UpdateAdDto(
    Guid Id,
    string Title,
    string? Content,
    string PictureUrl,
    string? VideoUrl,
    AdPlacement Placement,
    AdReferralType ReferralType,
    Guid? ReferralId,
    string? ExternalUrl,
    AdTargetAudience TargetAudience,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActive,
    int Priority,
    decimal? Budget
);
