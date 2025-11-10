using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.ContentManagement;

public class OfferClaim : BaseEntity<Guid>
{
    // Foreign Keys
    public Guid OfferId { get; set; }
    public Offer Offer { get; set; } = null!;

    public string UserId { get; set; } = default!;
    public ApplicationUser User { get; set; } = null!;

    // Core Fields
    public string ClaimCode { get; set; } = string.Empty;
    public bool IsRedeemed { get; set; } = false;
    public DateTimeOffset? RedeemedAt { get; set; }
    public string? RedemptionLocation { get; set; }

    public DateTimeOffset ExpiresAt { get; set; }
    public DateTimeOffset ClaimedAt { get; set; } = DateTimeOffset.UtcNow;
}