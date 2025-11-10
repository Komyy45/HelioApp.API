using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.ContentManagement;

public class Offer : BaseEntity<Guid>
{
    public Guid? ServiceId { get; set; }
    public string CreatedById { get; set; }

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? TermsAndConditions { get; set; }
    public string PictureUrl { get; set; } = default!;

    public OfferType OfferType { get; set; } = OfferType.Other;
    public int? DiscountPercentage { get; set; }
    public decimal? DiscountAmount { get; set; }
    public RedemptionMethod RedemptionMethod { get; set; } = RedemptionMethod.Automatic;

    public int? MaxRedemptions { get; set; }
    public int CurrentRedemptions { get; set; } = 0;
    public bool RequiresCode { get; set; } = false;

    public OfferStatus Status { get; set; } = OfferStatus.Draft;

    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }

    public int ViewCount { get; set; } = 0;
    public int ClaimCount { get; set; } = 0;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }

    // Navigation properties
    public Service? Service { get; set; }
    public ApplicationUser CreatedBy { get; set; } = default!;
}