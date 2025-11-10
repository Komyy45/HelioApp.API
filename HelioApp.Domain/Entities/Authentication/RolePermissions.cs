namespace HelioApp.Domain.Entities.Authentication;

public sealed class RolePermissions
{
    public Guid Id { get; set; }

    public string RoleId { get; set; } = default!;
    public Guid PermissionId { get; set; }

    public ApplicationRole Role { get; set; } = default!;
    public Permission Permission { get; set; } = default!;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}