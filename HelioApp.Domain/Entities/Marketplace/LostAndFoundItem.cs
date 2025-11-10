using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Marketplace;

public class LostAndFoundItem : BaseEntity<Guid>
{

    // Foreign Key
    public string PosterId { get; set; }
    public ApplicationUser Poster { get; set; } = null!;

    // Fields
    public LostAndFoundItemType ItemType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateOnly DateLostOrFound { get; set; }

    // Store multiple image URLs in JSON format
    public List<string>? Images { get; set; }

    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }

    public LostAndFoundItemStatus Status { get; set; } = LostAndFoundItemStatus.Pending;

    public int ViewCount { get; set; } = 0;
    public DateTime? ExpiresAt { get; set; }
    public DateTime? ResolvedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}