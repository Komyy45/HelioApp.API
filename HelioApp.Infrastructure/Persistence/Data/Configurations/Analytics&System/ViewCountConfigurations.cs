using HelioApp.Domain.Entities.Analytics_System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Analytics_System
{
    public sealed class ViewCountConfigurations : IEntityTypeConfiguration<ViewCount>
    {
        public void Configure(EntityTypeBuilder<ViewCount> builder)
        {
            builder.ToTable("ViewCounts");

            builder.HasKey(vc => vc.Id);

            builder.HasIndex(vc => vc.ViewableType);
            builder.HasIndex(vc => vc.ViewableId);
            builder.HasIndex(vc => vc.UserId);
            builder.HasIndex(vc => vc.ViewedAt);

            builder.Property(vc => vc.Id)
                .HasColumnName("id");

            builder.Property(vc => vc.ViewableType)
                .HasColumnName("viewable_type")
                .IsRequired();

            builder.Property(vc => vc.ViewableId)
                .HasColumnName("viewable_id")
                .IsRequired();

            builder.Property(vc => vc.UserId)
                .HasColumnName("user_id");

            builder.Property(vc => vc.IpAddress)
                .HasColumnName("ip_address");

            builder.Property(vc => vc.UserAgent)
                .HasColumnName("user_agent")
                .HasColumnType("nvarchar(max)");

            builder.Property(vc => vc.ViewedAt)
                .HasColumnName("viewed_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(vc => vc.User)
                .WithMany()
                .HasForeignKey(vc => vc.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
