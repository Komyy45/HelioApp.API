using HelioApp.Domain.Enums;
namespace HelioApp.Application.DTOs.ContentManagement;

public sealed record NotificationDto(
    Guid Id,
    string Title,
    string Content,
    NotificationType NotificationType,
    string? PictureUrl,
    string? ActionUrl,
    NotificationTargetAudience TargetAudience,
    List<string>? SpecificUserIds,
    NotificationPriority Priority,
    DateTime StartDate,
    DateTime EndDate,
    bool IsActive,
    int SentCount,
    int ReadCount,
    DateTime CreatedAt
);