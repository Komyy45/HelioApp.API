using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.Authentication;

public sealed class ApplicationRole : BaseEntity<string>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}