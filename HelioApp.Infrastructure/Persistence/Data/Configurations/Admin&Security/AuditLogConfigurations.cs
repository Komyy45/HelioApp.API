using HelioApp.Domain.Entities.Admin_Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Admin_Security
{
    // public sealed class AuditLogConfigurations : IEntityTypeConfiguration<AuditLog>
    // {
    //     public void Configure(EntityTypeBuilder<AuditLog> builder)
    //     {
    //         builder.ToTable("AuditLogs");
    //
    //         builder.HasKey(al => al.Id);
    //
    //         //builder.HasIndex(al => al.AdminId);
    //         builder.HasIndex(al => al.Action);
    //         builder.HasIndex(al => al.EntityType);
    //         builder.HasIndex(al => al.EntityId);
    //         builder.HasIndex(al => al.CreatedAt);
    //
    //         builder.Property(al => al.Id)
    //             .HasColumnName("id");
    //
    //         // builder.Property(al => al.AdminId)
    //         //     .HasColumnName("admin_id")
    //         //     .IsRequired();
    //
    //         builder.Property(al => al.Action)
    //             .HasColumnName("action")
    //             .IsRequired();
    //
    //         builder.Property(al => al.EntityType)
    //             .HasColumnName("entity_type")
    //             .IsRequired();
    //
    //         builder.Property(al => al.EntityId)
    //             .HasColumnName("entity_id")
    //             .IsRequired();
    //
    //         builder.Property(al => al.EntityTitle)
    //             .HasColumnName("entity_title");
    //
    //         builder.Property(al => al.OldValues)
    //             .HasColumnName("old_values")
    //             .HasColumnType("nvarchar(max)"); 
    //
    //         builder.Property(al => al.NewValues)
    //             .HasColumnName("new_values")
    //             .HasColumnType("nvarchar(max)"); 
    //
    //         builder.Property(al => al.IpAddress)
    //             .HasColumnName("ip_address");
    //
    //         builder.Property(al => al.UserAgent)
    //             .HasColumnName("user_agent")
    //             .HasColumnType("nvarchar(max)");
    //
    //         builder.Property(al => al.Description)
    //             .HasColumnName("description")
    //             .HasColumnType("nvarchar(max)");
    //
    //         builder.Property(al => al.CreatedAt)
    //             .HasColumnName("created_at")
    //             .HasDefaultValueSql("SYSUTCDATETIME()");
    //
    //         // Relationships
    //         // builder.HasOne(al => al.Admin)
    //         //     .WithMany(a => a.AuditLogs)
    //         //     .HasForeignKey(al => al.AdminId)
    //         //     .OnDelete(DeleteBehavior.Cascade);
    //     }
    // }
}
