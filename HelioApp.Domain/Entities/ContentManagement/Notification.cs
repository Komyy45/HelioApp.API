using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.ContentManagement;

public class Notification : BaseEntity<Guid>
{

    // Foreign Key
    public string CreatedBy { get; set; } = default!;
    public ApplicationUser CreatedByUser { get; set; } = null!;

    // Core Fields
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public NotificationType NotificationType { get; set; }
    public string? PictureUrl { get; set; }
    public string? ActionUrl { get; set; }

    public NotificationTargetAudience TargetAudience { get; set; }
    public List<Guid>? SpecificUserIds { get; set; }

    public NotificationPriority Priority { get; set; } = NotificationPriority.Normal;

    // Timing & Status
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;

    // Analytics
    public int SentCount { get; set; } = 0;
    public int ReadCount { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
