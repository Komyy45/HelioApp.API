using HelioApp.Domain.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Messaging
{
    public sealed class ConversationParticipantConfigurations : IEntityTypeConfiguration<ConversationParticipant>
    {
        public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
        {
            builder.ToTable("ConversationParticipants");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.ConversationId);
            builder.HasIndex(p => p.UserId);
            builder.HasIndex(p => p.UnreadCount);

            builder.HasIndex(p => new { p.ConversationId, p.UserId }).IsUnique();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ConversationId).HasColumnName("conversation_id").IsRequired();
            builder.Property(p => p.UserId).HasColumnName("user_id").IsRequired();

            builder.Property(p => p.Role)
                .HasColumnName("role")
                .HasDefaultValue("member");

            builder.Property(p => p.UnreadCount)
                .HasColumnName("unread_count")
                .HasDefaultValue(0);

            builder.Property(p => p.LastReadAt)
                .HasColumnName("last_read_at");

            builder.Property(p => p.IsMuted)
                .HasColumnName("is_muted")
                .HasDefaultValue(false);

            builder.Property(p => p.JoinedAt)
                .HasColumnName("joined_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(p => p.LeftAt)
                .HasColumnName("left_at");

            // Relationships
            builder.HasOne(p => p.Conversation)
                .WithMany(c => c.Participants)
                .HasForeignKey(p => p.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
