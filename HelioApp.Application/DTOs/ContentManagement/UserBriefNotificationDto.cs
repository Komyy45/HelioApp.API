namespace HelioApp.Application.DTOs.ContentManagement;
public sealed record UserBriefNotificationDto(
    Guid UserNotificationId,
    Guid NotificationId,
    string Title,
    string Content,
    DateTime SentAt,
    bool IsRead
);