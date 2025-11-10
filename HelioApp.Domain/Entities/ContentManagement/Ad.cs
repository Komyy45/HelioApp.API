using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.ContentManagement;

public class Ad : BaseEntity<Guid>
{
    // Foreign Key
    public string CreatedBy { get; set; } = default!;
    public ApplicationUser CreatedByUser { get; set; } = null!;

    // Core Fields
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
    public string? VideoUrl { get; set; }

    public AdPlacement Placement { get; set; }
    public AdReferralType ReferralType { get; set; }

    public Guid? ReferralId { get; set; }
    public string? ExternalUrl { get; set; }

    public AdTargetAudience TargetAudience { get; set; } = AdTargetAudience.All;

    // Statistics
    public int ImpressionCount { get; set; } = 0;
    public int ClickCount { get; set; } = 0;

    // Timing & Management
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public int Priority { get; set; } = 0;
    public decimal? Budget { get; set; }

    // Auditing
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}