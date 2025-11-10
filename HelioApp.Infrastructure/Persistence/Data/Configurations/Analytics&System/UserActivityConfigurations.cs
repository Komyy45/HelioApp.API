using HelioApp.Domain.Entities.Analytics_System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Analytics_System
{
    public sealed class UserActivityConfigurations : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.ToTable("UserActivities");

            builder.HasKey(ua => ua.Id);

            builder.HasIndex(ua => ua.UserId);
            builder.HasIndex(ua => ua.ActivityType);
            builder.HasIndex(ua => ua.CreatedAt);

            builder.Property(ua => ua.Id)
                .HasColumnName("id");

            builder.Property(ua => ua.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(ua => ua.ActivityType)
                .HasColumnName("activity_type")
                .IsRequired();

            builder.Property(ua => ua.RelatedType)
                .HasColumnName("related_type");

            builder.Property(ua => ua.RelatedId)
                .HasColumnName("related_id");

            builder.Property(ua => ua.Metadata)
                .HasColumnName("metadata")
                .HasColumnType("nvarchar(max)");

            builder.Property(ua => ua.IpAddress)
                .HasColumnName("ip_address");

            builder.Property(ua => ua.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(ua => ua.User)
                .WithMany()
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
