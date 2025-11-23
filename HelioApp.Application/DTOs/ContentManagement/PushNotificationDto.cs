using HelioApp.Domain.Enums;

namespace HelioApp.Application.DTOs.ContentManagement;

public sealed record PushNotificationDto(
    string Title,
    string Content,
    NotificationTargetAudience TargetAudience,
    List<string>? SpecificUserIds,
    DateTime StartDate
);