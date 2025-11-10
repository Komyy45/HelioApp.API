using HelioApp.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Authentication
{
    public class RolePermissionsConfiguration : IEntityTypeConfiguration<RolePermissions>
    {
        public void Configure(EntityTypeBuilder<RolePermissions> builder)
        {
            builder.ToTable("RolePermissions");

            builder.HasKey(rp => rp.Id);

            builder.Property(rp => rp.CreatedAt)
                   .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.HasOne(rp => rp.Role)
                   .WithMany()
                   .HasForeignKey(rp => rp.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rp => rp.Permission)
                   .WithMany()
                   .HasForeignKey(rp => rp.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
