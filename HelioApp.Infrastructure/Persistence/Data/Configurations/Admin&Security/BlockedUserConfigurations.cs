using HelioApp.Domain.Entities.Admin_Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Admin_Security
{
    public sealed class BlockedUserConfigurations : IEntityTypeConfiguration<BlockedUser>
    {
        public void Configure(EntityTypeBuilder<BlockedUser> builder)
        {
            builder.ToTable("BlockedUsers");

            builder.HasKey(bu => bu.Id);

            builder.HasIndex(bu => bu.BlockerId);
            builder.HasIndex(bu => bu.BlockedId);
            builder.HasIndex(bu => new { bu.BlockerId, bu.BlockedId }).IsUnique();

            builder.Property(bu => bu.Id)
                .HasColumnName("id");

            builder.Property(bu => bu.BlockerId)
                .HasColumnName("blocker_id")
                .IsRequired();

            builder.Property(bu => bu.BlockedId)
                .HasColumnName("blocked_id")
                .IsRequired();

            builder.Property(bu => bu.Reason)
                .HasColumnName("reason")
                .HasColumnType("nvarchar(max)");

            builder.Property(bu => bu.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(bu => bu.Blocker)
                .WithMany() 
                .HasForeignKey(bu => bu.BlockerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bu => bu.Blocked)
                .WithMany() 
                .HasForeignKey(bu => bu.BlockedId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
