using HelioApp.Domain.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Messaging
{
    public sealed class MessageReadReceiptConfigurations : IEntityTypeConfiguration<MessageReadReceipt>
    {
        public void Configure(EntityTypeBuilder<MessageReadReceipt> builder)
        {
            builder.ToTable("MessageReadReceipts");

            builder.HasKey(r => r.Id);

            builder.HasIndex(r => r.MessageId);
            builder.HasIndex(r => r.UserId);
            builder.HasIndex(r => new { r.MessageId, r.UserId }).IsUnique();

            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.MessageId).HasColumnName("message_id").IsRequired();
            builder.Property(r => r.UserId).HasColumnName("user_id").IsRequired();

            builder.Property(r => r.ReadAt)
                .HasColumnName("read_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(r => r.Message)
                .WithMany(m => m.ReadReceipts)
                .HasForeignKey(r => r.MessageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
