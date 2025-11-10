using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Reviews;

public sealed class Review : BaseEntity<Guid>
{
    public Guid ServiceId { get; set; }
    public string AuthorId { get; set; } = default!;

    public int Rating { get; set; } // 1–5
    public string? Title { get; set; }
    public string Body { get; set; } = default!;
    public List<string>? Images { get; set; }

    public bool IsVerifiedPurchase { get; set; } = false;
    public int HelpfulCount { get; set; } = 0;

    public ReviewStatus Status { get; set; } = ReviewStatus.Pending;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Relationships
    public ApplicationUser Author { get; set; } = default!;
    public Service Service { get; set; } = default!;
    public ReviewReply? Reply { get; set; }
}