using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Marketplace;

public class MarketplaceItem : BaseEntity<Guid>
{
    public string SellerId { get; set; } = default!;

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string Currency { get; set; } = "EGP";
    public string? Category { get; set; }

    public ItemCondition Condition { get; set; } = ItemCondition.Good;
    public string Location { get; set; } = default!;
    public List<string> Images { get; set; } = new();
    public ContactMethod ContactMethod { get; set; } = ContactMethod.All;
    public ItemStatus Status { get; set; } = ItemStatus.Pending;

    public int ViewCount { get; set; } = 0;
    public bool IsNegotiable { get; set; } = true;

    public DateTimeOffset? ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public ApplicationUser Seller { get; set; } = default!;
}