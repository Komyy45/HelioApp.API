using HelioApp.Domain.Common;

namespace HelioApp.Domain.Entities.Authentication;

public sealed class Permission : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Module { get; set; } = default!;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}