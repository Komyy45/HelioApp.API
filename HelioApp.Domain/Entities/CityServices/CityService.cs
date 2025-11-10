using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.CityServices;

public class CityService : BaseEntity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string? TitleAr { get; set; }
    public string? Description { get; set; }

    public string? Category { get; set; }
    public string? IconUrl { get; set; }
    public string? Slap { get; set; }
    public string? DocumentUrl { get; set; }

    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? WebsiteUrl { get; set; }

    public string? Location { get; set; }

    public List<string> WorkingHours { get; set; }

    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; } = 0;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}