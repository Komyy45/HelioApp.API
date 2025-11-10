using HelioApp.Domain.Entities.ContentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.ContentManagement
{
    public sealed class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.ToTable("UserNotifications");

            builder.HasKey(un => un.Id);

            builder.Property(un => un.Id).HasColumnName("id");

            builder.Property(un => un.NotificationId).HasColumnName("notification_id").IsRequired();
            builder.HasOne(un => un.Notification)
                   .WithMany()
                   .HasForeignKey(un => un.NotificationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(un => un.UserId).HasColumnName("user_id").IsRequired();
            builder.HasOne(un => un.User)
                   .WithMany()
                   .HasForeignKey(un => un.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(un => un.IsRead).HasColumnName("is_read").HasDefaultValue(false);
            builder.Property(un => un.ReadAt).HasColumnName("read_at");
            builder.Property(un => un.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
