using HelioApp.Domain.Entities.Admin_Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Admin_Security
{
    // public sealed class AdminUserConfigurations : IEntityTypeConfiguration<AdminUser>
    // {
    //     public void Configure(EntityTypeBuilder<AdminUser> builder)
    //     {
    //         builder.ToTable("AdminUsers");
    //
    //         builder.HasKey(a => a.Id);
    //
    //         // builder.HasIndex(a => a.Email).IsUnique();
    //         // builder.HasIndex(a => a.AdminRole);
    //         // builder.HasIndex(a => a.IsActive);
    //         //
    //         // builder.Property(a => a.Id)
    //         //     .HasColumnName("id");
    //         //
    //         // builder.Property(a => a.Email)
    //         //     .HasColumnName("email")
    //         //     .IsRequired();
    //         //
    //         // builder.Property(a => a.PasswordHash)
    //         //     .HasColumnName("password_hash")
    //         //     .IsRequired();
    //         //
    //         // builder.Property(a => a.Name)
    //         //     .HasColumnName("name")
    //         //     .IsRequired();
    //         //
    //         // builder.Property(a => a.Phone)
    //         //     .HasColumnName("phone");
    //         //
    //         // builder.Property(a => a.ProfilePictureUrl)
    //         //     .HasColumnName("profile_picture_url");
    //         //
    //         // builder.Property(a => a.AdminRole)
    //         //     .HasColumnName("admin_role")
    //         //     .HasConversion<string>() 
    //         //     .IsRequired();
    //         //
    //         // builder.Property(a => a.Permissions)
    //         //     .HasColumnName("permissions")
    //         //     .HasColumnType("nvarchar(max)"); 
    //         //
    //         // builder.Property(a => a.IsActive)
    //         //     .HasColumnName("is_active")
    //         //     .HasDefaultValue(true);
    //         //
    //         // builder.Property(a => a.LastLoginAt)
    //         //     .HasColumnName("last_login_at");
    //         //
    //         // builder.Property(a => a.CreatedAt)
    //         //     .HasColumnName("created_at")
    //         //     .HasDefaultValueSql("SYSUTCDATETIME()")
    //         //     .ValueGeneratedOnAdd();
    //         //
    //         // builder.Property(a => a.UpdatedAt)
    //         //     .HasColumnName("updated_at")
    //         //     .HasDefaultValueSql("SYSUTCDATETIME()")
    //         //     .ValueGeneratedOnAddOrUpdate();
    //         //
    //         //
    //         // builder.HasMany(a => a.AuditLogs)
    //         //     .WithOne(al => al.Admin)
    //         //     .HasForeignKey(al => al.AdminId)
    //         //     .OnDelete(DeleteBehavior.Cascade);
    //         //
    //         // // Additional configuration notes:
    //         // // - keep property column naming consistent with DB naming (snake_case)
    //         // // - permissions stored as JSON text in nvarchar; parsing handled at service layer if needed
    //     }
    // }
}
