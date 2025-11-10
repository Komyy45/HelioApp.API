using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).HasColumnName("id");

            builder.Property(n => n.CreatedBy).HasColumnName("created_by").IsRequired();

            builder.HasOne(n => n.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(n => n.CreatedBy)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(n => n.Title).HasColumnName("title").IsRequired();
            builder.Property(n => n.Content).HasColumnName("content").IsRequired();

            builder.Property(n => n.NotificationType)
                   .HasColumnName("notification_type")
                   .HasConversion<byte>()
                   .IsRequired();

            builder.Property(n => n.PictureUrl).HasColumnName("picture_url");
            builder.Property(n => n.ActionUrl).HasColumnName("action_url");

            builder.Property(n => n.TargetAudience)
                   .HasColumnName("target_audience")
                   .HasConversion<byte>()
                   .IsRequired();

            builder.Property(n => n.SpecificUserIds)
                   .HasColumnName("specific_user_ids")
                   .HasColumnType("nvarchar(max)");

            builder.Property(n => n.Priority)
                   .HasColumnName("priority")
                   .HasConversion<byte>();

            builder.Property(n => n.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(n => n.EndDate).HasColumnName("end_date").IsRequired();

            builder.Property(n => n.IsActive).HasColumnName("is_active").HasDefaultValue(true);

            builder.Property(n => n.SentCount).HasColumnName("sent_count").HasDefaultValue(0);
            builder.Property(n => n.ReadCount).HasColumnName("read_count").HasDefaultValue(0);

            builder.Property(n => n.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("GETUTCDATE()");
            builder.Property(n => n.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
