using HelioApp.Domain.Enums;
namespace HelioApp.Application.DTOs.ContentManagement;

public sealed record CreateNotificationDto(
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
    string CreatedBy 
);