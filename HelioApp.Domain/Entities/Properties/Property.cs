using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.Properties;

public class Property : BaseEntity<Guid>
{
    // Foreign Key
    public string OwnerId { get; set; } = default!;

    // Navigation Property
    public ApplicationUser Owner { get; set; } = default!;

    // Basic Info
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public PropertyType PropertyType { get; set; }

    // Pricing
    public decimal Price { get; set; }

    // Location
    public string Location { get; set; } = default!;

    // Media & Extras
    public string Amenities { get; set; } = default!;
    public List<string> Images { get; set; } = default!;

    // Contact
    public string ContactName { get; set; } = default!;
    public string ContactPhone { get; set; } = default!;
    
    // Dates
    public DateTimeOffset? ExpiresAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; } // soft delete
}