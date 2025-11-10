using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.ContentManagement;

public class UserNotification : BaseEntity<Guid>
{
    public Guid NotificationId { get; set; }
    public string UserId { get; set; } = default!;

    public bool IsRead { get; set; } = false;
    public DateTimeOffset? ReadAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // Navigation properties
    public Notification Notification { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
}