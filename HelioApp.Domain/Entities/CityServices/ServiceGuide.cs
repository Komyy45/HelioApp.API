using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.CityServices;

public class ServiceGuide : BaseEntity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string? TitleAr { get; set; }

    public string Content { get; set; } = string.Empty;

    public string? Category { get; set; }
    public string? IconUrl { get; set; }
    public string? PdfUrl { get; set; }

    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; } = 0;
    public int ViewCount { get; set; } = 0;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}