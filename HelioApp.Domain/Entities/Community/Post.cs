using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Community;

public sealed class Post : BaseEntity<Guid>
{
    // Foreign Keys
    public string AuthorId { get; set; } = default!;
    public Guid? CircleId { get; set; }

    // Navigation Properties
    public ApplicationUser Author { get; set; } = default!;
    public DiscussionCircle? Circle { get; set; }

    // Core Content
    public string? Title { get; set; }
    public string Content { get; set; } = default!;
    public PostType PostType { get; set; } = PostType.Text;

    // Media
    public string? Images { get; set; } // JSON array

    // Flags
    public bool IsPinned { get; set; } = false;
    public bool IsLocked { get; set; } = false;

    // Status
    public PostStatus Status { get; set; } = PostStatus.Published;

    // Metrics
    public int LikesCount { get; set; } = 0;
    public int CommentsCount { get; set; } = 0;
    public int ViewCount { get; set; } = 0;
    public int ReportsCount { get; set; } = 0;

    // Audit Fields
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; } // soft delete
}