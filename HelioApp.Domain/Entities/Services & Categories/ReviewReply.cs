using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Reviews;

public sealed class ReviewReply : BaseEntity<Guid>
{
    // Foreign Keys
    public Guid ReviewId { get; set; }
    public string AuthorId { get; set; } = default!;

    // Navigation Properties
    public Review Review { get; set; } = default!;
    public ApplicationUser Author { get; set; } = default!; // could also reference AdminUser later

    public ReviewReplyAuthorType AuthorType { get; set; }
    public string Content { get; set; } = default!;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
}