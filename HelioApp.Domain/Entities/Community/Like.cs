using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Community;

public sealed class Like : BaseEntity<Guid>
{
    public string UserId { get; set; } = default!;
    public string LikeableType { get; set; } = default!;
    public Guid LikeableId { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public ApplicationUser? User { get; set; }
}