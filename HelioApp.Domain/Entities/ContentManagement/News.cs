using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Authentication;

namespace HelioApp.Domain.Entities.ContentManagement;

public class News : BaseEntity<Guid>
{
    // Foreign Key
    public string AuthorId { get; set; } = default!;
    public ApplicationUser Author { get; set; } = null!;

    // Core Fields
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Summary { get; set; }

    public string FeaturedImageUrl { get; set; } = string.Empty;
    public List<string>? Images { get; set; }

    public string? ExternalUrl { get; set; }
    public string? Category { get; set; }  // e.g., 'events', 'announcements', 'updates'

    public bool IsFeatured { get; set; } = false;
    public bool IsPublished { get; set; } = true;

    public int ViewCount { get; set; } = 0;

    public DateTime? PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
