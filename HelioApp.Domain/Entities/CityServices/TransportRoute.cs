using HelioApp.Domain.Common;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.CityServices;

public class TransportRoute : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? NameAr { get; set; }

    public string? RouteNumber { get; set; }

    public TransportType TransportType { get; set; }

    public string StartPoint { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;

    // JSON array of stops (e.g. ["Station A", "Station B", "Station C"])
    public List<string>? Stops { get; set; } = new();

    public string? RouteMapUrl { get; set; }
    public decimal? Fare { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}
