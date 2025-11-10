using HelioApp.Domain.Common;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.CityServices;

public class EmergencyContact : BaseEntity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string? TitleAr { get; set; }    

    public EmergencyContactType Type { get; set; }

    public string Number { get; set; } = string.Empty;
    public string? SecondaryNumber { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
    public int DisplayOrder { get; set; } = 0;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
