using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.ContentManagement;

public class OfferCode : BaseEntity<Guid>
{
    // Foreign Key
    public Guid OfferId { get; set; }
    public Offer Offer { get; set; } = null!;

    // Core Fields
    public string Code { get; set; } = string.Empty;
    public bool IsUsed { get; set; } = false;

    public string? UsedBy { get; set; } = default!;
    public ApplicationUser? User { get; set; }

    public DateTimeOffset? UsedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}