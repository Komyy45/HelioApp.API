using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.Community;

public class DiscussionCircle : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string? NameAr { get; set; }
    public string? Description { get; set; }
    public string? IconUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? Rules { get; set; }

    public bool IsActive { get; set; } = true;
    public int PostsCount { get; set; } = 0;
    public int MembersCount { get; set; } = 0;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
}